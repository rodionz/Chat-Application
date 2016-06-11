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
        public static TcpClient client;
        public static NetworkStream localNetStream;
        public static BinaryFormatter bFormatt;




        public static void MainClienFinction(MessageData mesData, NetworkAction action)

        {
            //TcpClient client;

            if (action == NetworkAction.Connection)
            {
                 client = new TcpClient();
                Task t1 = Task.Run(() => ConnecttoServer(mesData, client));
            }


            else if (action == NetworkAction.IpandPortValidaton)
            {
                TcpClient client2 = new TcpClient();
                Task t2 = Task.Run(() => IpandPortValidaton(mesData, client2));

            }
        }

        private static void IpandPortValidaton(MessageData mesData, TcpClient client2)
        {
            MessageData returning;
            try
            {
                client2.Connect(mesData.Userdat.IPadress, mesData.Userdat.Portnumber);

                NetworkStream netStream = client2.GetStream();
              
                    GlobalValidIpandPort = true;
                   BinaryFormatter aFormatt = new BinaryFormatter();
               

                    aFormatt.Serialize(netStream, mesData);
                if (netStream.DataAvailable)
                {
                    returning = (MessageData)aFormatt.Deserialize(netStream);
                    listofUserfortheUsers = returning.listofUsers;
                }  
                
            }

            catch (SocketException SE)
            {
                NoServer();
            }

            //finally
            //{
                //client2.Close();
            //}
        }

        private static void ConnecttoServer(MessageData mesData, TcpClient client)
        {
            NetworkStream stream;
            client.Connect(IPAddress.Parse(mesData.Userdat.IPadress), mesData.Userdat.Portnumber);

            while(true)
            {
                stream = client.GetStream();
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatt.Serialize(stream, mesData);


            }
        }








        //public static void MainClienFinction(MessageData mesData, NetworkAction action)

        //{
        //    Task t2 = Task.Run(() => ConnecttoServer(mesData));
        //}


        //public static void  IPAndPortValidation(MessageData premesData)

        //{
        //    MessageData returning;

        //    TcpClient preclient = new TcpClient();

        //    try
        //    {
        //        preclient.Connect(premesData.Userdat.IPadress, premesData.Userdat.Portnumber);

        //        using (NetworkStream netStream = preclient.GetStream())
        //        {
        //            bFormatt = new BinaryFormatter();
        //            bFormatt.Serialize(netStream, premesData);
        //            returning = (MessageData)bFormatt.Deserialize(netStream);
        //            listofUserfortheUsers = returning.listofUsers;
        //            GlobalValidIpandPort = true;
        //        }
        //    }

        //    catch (SocketException SE)
        //    {
        //        NoServer();
        //    }

        //    finally
        //    {
        //        preclient.Close();
        //    }

        //}




        //public static void ConnecttoServer (MessageData mData,TcpClient client)
        //{

        //    client.Connect(IPAddress.Parse (mData.Userdat.IPadress), mData.Userdat.Portnumber );
        //    bFormatt = new BinaryFormatter();
        //    localNetStream = client.GetStream();
        //    Task listenig = Task.Run(() => StarListentoIncomingMessages(localNetStream));
        //    //bFormatt.Serialize(localNetStream, mData);


        //}

        //private static void StarListentoIncomingMessages(NetworkStream userNetstrem)
        //{
        //    while(true)
        //    {
        //        if (userNetstrem.DataAvailable)
        //        {
        //            bFormatt = new BinaryFormatter();
        //            LockalmesData = (MessageData)bFormatt.Deserialize(localNetStream);
        //            MessageRecieved(LockalmesData);
        //        }
        //    }
        //}


        //private static void SendMessage(MessageData mesData, TcpClient clien3)
        //{

        //    //clien3.Connect(IPAddress.Parse(mesData.Userdat.IPadress), mesData.Userdat.Portnumber);
        //   NetworkStream sendmessagstrem = clien3.GetStream();
        //   bFormatt = new BinaryFormatter();
        //    bFormatt.Serialize(localNetStream, mesData);
        //}





        //public void Disconnect()
        //{

        //}



        //public static void ColorwasChanged(UserData uData)
        //{


        //}

        //public static void FontwasChanged(UserData uData)
        //{

        //}
    }
}
