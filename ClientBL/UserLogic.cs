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
        public static List<UserData> listofUserfortheUsers;
        public static bool GlobalValidIpandPort;
        public static  NetworkAction LolacAction;
        public static MessageData LockalmesData;






        public static void MainClienFinction(MessageData mesData)

        {            
         Task t1 = Task.Run(() =>   ConnecttoServer(mesData));

        
        }




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
            TcpClient client = new TcpClient();
            MessageData returning;
            client.Connect(IPAddress.Parse(mData.Userdat.IPadress), mData.Userdat.Portnumber);
            ClientBoolsandStreams.LocalClient = client;
            NetworkStream stream;
            BinaryFormatter Bformat = new BinaryFormatter();   
            stream = client.GetStream();
            Bformat.Serialize(stream, mData);           
            ClientBoolsandStreams.UserisOnline = true;

            stream.Flush();

            Task listening = Task.Run(() => StariListenToIncomingMessages());


        }

        private static void StariListenToIncomingMessages()
        {
            BinaryFormatter listerformatter = new BinaryFormatter();
            MessageData incoming;
            NetworkStream usernetstream = ClientBoolsandStreams.LocalClient.GetStream();

            while (ClientBoolsandStreams.UserisOnline)
            {
                if(usernetstream.DataAvailable)
                {
                    incoming = (MessageData)listerformatter.Deserialize(usernetstream);
                    MessageRecieved(incoming);
                    //usernetstream.Dispose();

                }

            }
        }

        public static void SendMessage(MessageData outcoming)
        {
            BinaryFormatter sendingformatter = new BinaryFormatter();
           NetworkStream localstrem = ClientBoolsandStreams.LocalClient.GetStream();
            sendingformatter.Serialize(localstrem, outcoming);

        }

        



    }
}
