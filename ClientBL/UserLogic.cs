using System;
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
      
        public static event Action<string> NoConnectionWhithServerEvent;
        public static event Action ServerDisconnected;      
        public static event Action<MessageData> MessageRecieved;



        public static bool GlobalValidIpandPort;
        public static  NetworkAction LolacAction;
        public static MessageData LockalmesData;
        private static TcpClient client;
       
        static Task listening;



      


        // The separate function fot IP and Port validation was intended, besides validating it returns list of Usernames for the folowing username validation

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

            catch (SocketException)
            {
                GlobalValidIpandPort = false;
                NoConnectionWhithServerEvent("There is no server whith these parameters ");
            }

            finally
            {
                preclient.Close();
            }

        }




        public  async static void ConnecttoServer(MessageData mData, UserData uData)
        {
           



            client = new TcpClient();
            MessageData returning = new MessageData();
            UserData Localuser = uData;
            client.Connect(IPAddress.Parse(mData.Userdat.IPadress), mData.Userdat.Portnumber);
            ClientProps.LocalClient = client;
            BinaryFormatter Bformat = new BinaryFormatter();        
            NetworkStream stream = client.GetStream();
            ClientProps.clientStream = stream;


            // This Feature Provides information of each clent's IP and Port to the Server

            string local = client.Client.LocalEndPoint.ToString();
            char[] separ = { ':' };
            string [] ipandport = local.Split(separ);
            mData.Userdat.IPadress = ipandport[0];
            mData.Userdat.Portnumber = int.Parse (ipandport[1]);
//////////////////////////////////////////////////////////////////////////


            Bformat.Serialize(stream, mData);           
            ClientProps.UserisOnline = true;
            stream.Flush();
             listening = Task.Run(() => StariListenToIncomingMessages(Localuser));
            await listening;
            listening.Dispose();
        }

        private static void StariListenToIncomingMessages(UserData currentUser)
        {
            BinaryFormatter listerformatter = new BinaryFormatter();
            MessageData incoming = new MessageData();
            NetworkStream usernetstream = ClientProps.clientStream;

            while (ClientProps.UserisOnline)
            {

                if (!usernetstream.CanRead || ClientProps.shutdown)
                {
                    client.Close();
                    return;
                }

                if(usernetstream.DataAvailable)
                {
                    incoming = (MessageData)listerformatter.Deserialize(usernetstream);

                    if (incoming.action == NetworkAction.ConectionREsponse && incoming.Userdat.Username == currentUser.Username)
                    {
                        currentUser.Userid = incoming.Userdat.Userid;
                        MessageRecieved(incoming);
                    }




                    else if (incoming.action == NetworkAction.SeverDisconnection)
                    {
                        MessageRecieved(incoming);
                        ServerDisconnected();
                        ClientProps.UserisOnline = false;

                        usernetstream.Dispose();
                        client.Close();
                    }


                    //else if (incoming.action == NetworkAction.UserDisconnection && incoming.Userdat.Username == currentUser.Username)
                    //{
                    //    client.Close();
                    //    return;
                    //}

                    else
                        MessageRecieved(incoming);

                }

                incoming.action = NetworkAction.None;
            }
            
            return;
        }


        public static void SendMessage(MessageData outcoming)
        {

            try
            {
                
                BinaryFormatter sendingformatter = new BinaryFormatter();
                NetworkStream localstrem = ClientProps.clientStream;
                sendingformatter.Serialize(localstrem, outcoming);

                if(!localstrem.DataAvailable)
                {
                  /* This exeption throws in the case of network disconnection on server side.
                    According to my observation, when there is no data available in the stream, immidiatly after
                    serialisation to that stream, it means that data had "disapeared", that  means that
                    there is network interference or disconnection on the server side
                   */
                    throw new ArgumentException();
                }
            }

            catch(IOException)

            {
                ClientProps.UserisOnline = false;
                NoConnectionWhithServerEvent("Server was suddenly disconnected");
                client.Close();
            }


            // This exeption has been throwing when network cable disconnects on the clientside
            catch(ArgumentException)
            {

                //// to think
            }
        }


       


       public static void Disconnection( UserData uData)

        {

            GlobalValidIpandPort = false;           
            MessageData mData = new MessageData(uData, NetworkAction.UserDisconnection);          
            BinaryFormatter disconnect = new BinaryFormatter();
            NetworkStream local = ClientProps.clientStream;
            disconnect.Serialize(local, mData);
            client.Close();

        }

     


    }
}
