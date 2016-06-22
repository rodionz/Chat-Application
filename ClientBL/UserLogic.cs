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

        public  delegate void Exseptions();
        public delegate void ClientBLEvents(MessageData mDAta);
        public static event Exseptions NoServer;
        public static event ClientBLEvents MessageRecieved;
        public static event ClientBLEvents Disconnect;
      
        public static bool GlobalValidIpandPort;
        public static  NetworkAction LolacAction;
        public static MessageData LockalmesData;



      private static  TcpClient client = new TcpClient();


        public static void MainClienFinction(MessageData mesData)

        {
            Disconnect += DisconnectionEventHandler;         
         Task t1 = Task.Run(() =>   ConnecttoServer(mesData));

        
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




        public static void ConnecttoServer(MessageData mData)
        {
            TcpClient client = new TcpClient();
            MessageData returning = new MessageData();
            client.Connect(IPAddress.Parse(mData.Userdat.IPadress), mData.Userdat.Portnumber);
            ClientProps.LocalClient = client;
            //NetworkStream stream;
            BinaryFormatter Bformat = new BinaryFormatter();
            //stream = client.GetStream();

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

            Task listening = Task.Run(() => StariListenToIncomingMessages());


        }

        private static void StariListenToIncomingMessages()
        {
            BinaryFormatter listerformatter = new BinaryFormatter();
            MessageData incoming = new MessageData();
            NetworkStream usernetstream = ClientProps.clientStream;

            while (ClientProps.UserisOnline)
            {
                if(usernetstream.DataAvailable)
                {
                    incoming = (MessageData)listerformatter.Deserialize(usernetstream);
                    MessageRecieved(incoming);

                    // Here is a bug
                    if (incoming.action == NetworkAction.ConectionREsponse)
                        ClientProps.CurrentUserID = incoming.Userdat.Userid;

                }


            }
           
           
          


        }

        public static void SendMessage(MessageData outcoming)
        {

            try
            {
                outcoming.Userdat.Userid = ClientProps.CurrentUserID;
                BinaryFormatter sendingformatter = new BinaryFormatter();
                NetworkStream localstrem = ClientProps.clientStream;
                sendingformatter.Serialize(localstrem, outcoming);
            }

            catch(IOException)

            {
                NoServer();
            }
        }


       public static void DisconnectionEventHandler(MessageData mData)

        {
            mData.Userdat.Userid = ClientProps.CurrentUserID;
            mData.action = NetworkAction.UserDisconnection;
            BinaryFormatter disconnect = new BinaryFormatter();
            NetworkStream local = ClientProps.clientStream;
            disconnect.Serialize(local, mData);
            client.Close();

        }


    }
}
