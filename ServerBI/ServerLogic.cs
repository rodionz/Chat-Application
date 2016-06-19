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
       
        public delegate void ServerEvents( MessageData mData, NetworkStream nStream);


        public static event Exseptions NoServer;

        public static event ServerEvents ipandportvalidation;
        public static event ServerEvents connection;
        public static event ServerEvents publicmessage;
        public static event ServerEvents privatemesage;
        public static event ServerEvents dicsconnecter;




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
                dicsconnecter += ServerEventHandlers.DisconnectUser;

                //InterfaceDisconnecter += ServerEventHandlers.DisconnectUser;
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
                    TcpClient client = serv.AcceptTcpClient();                
                    Task StarttoListen = Task.Run(() => StartListeningtoMessages(client));
                }
            }
            catch (SocketException se)
            {

                NoServer();

            }
        }                                                                                   
                                                       

        private static void StartListeningtoMessages(TcpClient localient)
        {
            BinaryFormatter bf = new BinaryFormatter();
            NetworkStream netStr = localient.GetStream();        
            while (ServerProps.ServerisOnline)

            {
          
                while (!netStr.DataAvailable)
                {
                   
                }
                MessageData mData = (MessageData)bf.Deserialize(netStr);

            

                switch (mData.action)

                {
                    case NetworkAction.IpandPortValidaton:
                        ipandportvalidation(mData, netStr);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.Connection:
                        connection(mData, netStr);
                        mData.action = NetworkAction.ConectionREsponse;
                        publicmessage(mData, netStr);
                        break;

                    //Messages
                    case NetworkAction.Sendmessage:
                        publicmessage(mData, netStr);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.RequestforListofUsers:
                        privatemesage( mData, netStr);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.UserDisconnection:

                        ServerProps.listofUsersontheserver.RemoveAt((mData.Userdat.Userid) );
                        ServerProps.StreamsofClients.RemoveAt(mData.Userdat.Userid);
                        dicsconnecter(mData, netStr);
                        mData.action = NetworkAction.None;
                        //IdsAdjuction();
                        break;

                    case NetworkAction.None:
                       
                        break;
                        
                }


            }

        }

        public static void StopListening()

        {


        }


        internal static void IdsAdjuction()
        {
            for(int i = 0; i < ServerProps.listofUsersontheserver.Count; i++)
            {
                ServerProps.listofUsersontheserver[i].Userid = i;
                //ServerProps.StreamsofClients[i].

            }
        }

    }
}
