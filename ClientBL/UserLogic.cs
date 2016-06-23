using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using CommonTypes;
using System.IO;


namespace ClientBL
{
    public class UserLogic
    {

      
        public static event Action NoServer;
        public static event Action ServerDisconnected;      
        public static event Action<MessageData> MessageRecieved;      
        public static event Action<MessageData,UserData> Disconnect;
      

        public static bool GlobalValidIpandPort;
        public static  NetworkAction LolacAction;
        public static MessageData LockalmesData;
        private static  TcpClient client = new TcpClient();
        static Task t1;
        static Task listening;



        public static void MainClienFinction(MessageData mesData, UserData uData)

        {
            NoServer += NoServerHandler;
            Disconnect += DisconnectionEventHandler;         
             t1 = Task.Run(() =>   ConnecttoServer(mesData, uData));

       
        }


        // The separate function fot IP and Port validation was intended, besides validating it returns list of Usernames for the folowwing username validation

        public static void  IPAndPortValidation(MessageData premesData)

        {
            MessageData returning;
            
            TcpClient preclient = new TcpClient();

            try
            {
                preclient.Connect(premesData.Userdat.IPadress, premesData.Userdat.Portnumber);

                using (NetworkStream netStream = preclient.GetStream())
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(netStream, premesData);
                    returning = (MessageData)bFormat.Deserialize(netStream);
                   ClientProps.listofUserfortheUsers = returning.listofUsers;
                    GlobalValidIpandPort = true;
                }
            }

            catch (SocketException SE)
            {
                NoServer();
            }

            finally
            {
                preclient.Close();
            }

        }




        public static void ConnecttoServer(MessageData mData, UserData uData)
        {
            TcpClient client = new TcpClient();
            MessageData returning = new MessageData();
            UserData Localuser = uData;
            client.Connect(IPAddress.Parse(mData.Userdat.IPadress), mData.Userdat.Portnumber);
            ClientProps.LocalClient = client;
            BinaryFormatter Bformat = new BinaryFormatter();
         
            NetworkStream stream = client.GetStream();
            ClientProps.clientStream = stream;

            string local = client.Client.LocalEndPoint.ToString();
            char[] separ = { ':' };
            string [] ipandport = local.Split(separ);
            mData.Userdat.IPadress = ipandport[0];
            mData.Userdat.Portnumber = int.Parse (ipandport[1]);



            Bformat.Serialize(stream, mData);           
            ClientProps.UserisOnline = true;

            stream.Flush();

             listening = Task.Run(() => StariListenToIncomingMessages(Localuser));


        }

        private static void StariListenToIncomingMessages(UserData currentUser)
        {
            BinaryFormatter listerformatter = new BinaryFormatter();
            MessageData incoming = new MessageData();
            NetworkStream usernetstream = ClientProps.clientStream;

            while (ClientProps.UserisOnline)
            {
                if(usernetstream.DataAvailable)
                {
                    incoming = (MessageData)listerformatter.Deserialize(usernetstream);
                  

               
                    if (incoming.action == NetworkAction.ConectionREsponse && incoming.Userdat.Username == currentUser.Username)
                    {
                        currentUser.Userid = incoming.Userdat.Userid;
                        MessageRecieved(incoming);
                    }



                    // tO cHECK!!!!
                    else if (incoming.action == NetworkAction.SeverDisconnection)
                    {
                        MessageRecieved(incoming);
                        ServerDisconnected();
                        ClientProps.UserisOnline = false;
                        t1.Dispose();
                        usernetstream.Dispose();
                        client.Close();

                    }

                  
                    else if (incoming.action == NetworkAction.UserDisconnection && incoming.Userdat.Username == currentUser.Username)
                        break;

                    else
                        MessageRecieved(incoming);

                }

                incoming.action = NetworkAction.None;
            }
           
           
          


        }

        public static void SendMessage(MessageData outcoming)
        {

            try
            {
                
                BinaryFormatter sendingformatter = new BinaryFormatter();
                NetworkStream localstrem = ClientProps.clientStream;
                sendingformatter.Serialize(localstrem, outcoming);
            }

            catch(IOException)

            {
                NoServer();
            }
        }


       public static void DisconnectionEventHandler(MessageData mData, UserData uData)

        {

            NoServer -= NoServerHandler;
            Disconnect -= DisconnectionEventHandler;





            mData.action = NetworkAction.UserDisconnection;
            BinaryFormatter disconnect = new BinaryFormatter();
            NetworkStream local = ClientProps.clientStream;
            disconnect.Serialize(local, mData);
            
            
            t1.Dispose();
            client.Close();

        }

        public static void NoServerHandler()
        {
            
            t1.Dispose();
            client.Close();
        }


    }
}
