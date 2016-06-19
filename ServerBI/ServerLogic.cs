using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CommonTypes;
using System.IO;

namespace ServerBI
{
    public class ServerLogic
    {
        public delegate void Exseptions();
        public delegate void ServerEvents( MessageData mData);


        public static event Exseptions NoServer;

        public static event ServerEvents ipandportvalidation;
        public static event ServerEvents connection;
        public static event ServerEvents publicmessage;
        public static event ServerEvents privatemesage;
        public static event ServerEvents diconnecter;






        public static List<UserData> listofUsersontheserver = new List<UserData>();






        public static void ServerOnline(ServerData sData)

        {
            try
            {
                TcpListener server = new TcpListener(IPAddress.Parse(sData.IPadress), sData.Portnumber);
                ServerProps.ServerisOnline = true;
                ipandportvalidation += ServerEventHandlers.ValidationHandler;
                connection += ServerEventHandlers.ConnectionHandler;
                publicmessage += ServerEventHandlers.PublicMessageHandler;
                privatemesage += ServerEventHandlers.PrivateMessageHandler;
                diconnecter += ServerEventHandlers.DisconnectUser;
                Task t1 = Task.Run(() => StartListening(server, NetworkAction.Connection));
            }
            catch
            {
                NoServer();
            }
            }

        public static void StartListening(TcpListener serv, NetworkAction NecAct)

        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                //listofUsersontheserver = new List<UserData>();
                serv.Start();

                while (ServerProps.ServerisOnline)
                {

                    ServerProps.LocalClient = serv.AcceptTcpClient();
                  
                    Task StarttoListen = Task.Run(() => StartListeningtoMessages());
                }
            }
            catch (SocketException se)
            {

                NoServer();

            }
        }                                                                                   
           

             
                   
                  




        private static void StartListeningtoMessages()
        {
            BinaryFormatter bf = new BinaryFormatter();
            NetworkStream netStr = ServerProps.LocalClient.GetStream();
            ServerProps.LocalStream = netStr;

            while (ServerProps.ServerisOnline)

            {

           

                while (!netStr.DataAvailable)
                {
                   
                }
                MessageData mData = (MessageData)bf.Deserialize(netStr);

                switch (mData.action)

                {
                    case NetworkAction.IpandPortValidaton:
                        ipandportvalidation(mData);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.Connection:


                      



                        connection(mData);
                        mData.action = NetworkAction.ConectionREsponse;
                        publicmessage(mData);
                        break;

                    //Messages
                    case NetworkAction.Sendmessage:
                        publicmessage(mData);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.RequestforListofUsers:
                        privatemesage( mData);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.UserDisconnection:
                       
                        listofUsersontheserver.RemoveAt((mData.Userdat.Userid) );
                        ServerProps.StreamsofClients.RemoveAt(mData.Userdat.Userid);
                       
                        diconnecter(mData);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.None:
                       
                        break;
                        
                }


            }














        }

        public static void StopListening()

        {


        }

    }
}
