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
        public static List<UserData> listofUserfortheUsers;
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
                    listofUserfortheUsers = returning.listofUsers;
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
           
            MessageData returning = new MessageData();
            client.Connect(IPAddress.Parse(mData.Userdat.IPadress), mData.Userdat.Portnumber);
            ClientLogicBools.LocalClient = client;
            NetworkStream stream;
            BinaryFormatter Bformat = new BinaryFormatter();   
            stream = client.GetStream();
            string local = client.Client.LocalEndPoint.ToString();
            char[] separ = { ':' };
            string [] ipandport = local.Split(separ);
            mData.Userdat.IPadress = ipandport[0];
            mData.Userdat.Portnumber = int.Parse (ipandport[1]);
            Bformat.Serialize(stream, mData);           
            ClientLogicBools.UserisOnline = true;

            stream.Flush();

            Task listening = Task.Run(() => StariListenToIncomingMessages());


        }

        private static void StariListenToIncomingMessages()
        {
            BinaryFormatter listerformatter = new BinaryFormatter();
            MessageData incoming = new MessageData();
            NetworkStream usernetstream = ClientLogicBools.LocalClient.GetStream();

            while (ClientLogicBools.UserisOnline)
            {
                if(usernetstream.DataAvailable)
                {
                    incoming = (MessageData)listerformatter.Deserialize(usernetstream);
                    MessageRecieved(incoming);
                    if (incoming.action == NetworkAction.Connection)
                    ClientLogicBools.CurrentUserID = incoming.Userdat.Userid;

                }


            }
           
            Disconnect(incoming);
            client.Close();


        }

        public static void SendMessage(MessageData outcoming)
        {
            BinaryFormatter sendingformatter = new BinaryFormatter();
           NetworkStream localstrem = ClientLogicBools.LocalClient.GetStream();
            sendingformatter.Serialize(localstrem, outcoming);

        }


       private static void DisconnectionEventHandler(MessageData mData)

        {
            mData.action = NetworkAction.UserDisconnection;
            BinaryFormatter disconnect = new BinaryFormatter();
            NetworkStream local = ClientLogicBools.LocalClient.GetStream();
            disconnect.Serialize(local, mData);

        }


    }
}
