using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using CommonTypes;
using System.Net.NetworkInformation;

namespace ServerBI
{
    public class ServerLogic
    {
      
        public static event Action ServerShutDown;        
        public static event Action<MessageData, NetworkStream>   ipandportvalidation;
        public static event Action<MessageData, NetworkStream> connection;
        public static event Action<MessageData, NetworkStream> publicmessage;
        public static event Action<MessageData, NetworkStream> ListofUsersRequest;
        public static event Action<MessageData, NetworkStream, UserData> Userdicsconnecter;      
        public static event Action<MessageData, NetworkStream> PrivateMessage;


        private static TcpListener server;
         static Task mainTask;
        static Task StarttoListen;

        public async static void ServerOnline(ServerData sData)

        {
           
                server = new TcpListener(IPAddress.Parse(sData.IPadress), sData.Portnumber);
                ServerProps.ServerisOnline = true;


                ipandportvalidation += ServerEventHandlers.IPandPortValidationHandler;
                connection += ServerEventHandlers.ConnectionHandler;
                publicmessage += ServerEventHandlers.PublicMessageHandler;
                ListofUsersRequest += ServerEventHandlers.UserREquestHandler;
                Userdicsconnecter += ServerEventHandlers.DisconnectUser;
                PrivateMessage += ServerEventHandlers.PrivatemessageHandler;
                ServerEventHandlers.unexpectedUserDisconnection_fortheInterface += ServerEventHandlers.UnexpectedDisconnectionHandler;
                mainTask = Task.Run(() => WaitingforNewConnections(server, NetworkAction.Connection));
                await mainTask;
                mainTask.Dispose();
           

        }

        public static void WaitingforNewConnections(TcpListener serv, NetworkAction NecAct)

        {
            try
            {
                               
                serv.Start();

                while (ServerProps.ServerisOnline)
                {
                    //exit point for function in order to complete task
                    if (!ServerProps.ServerisOnline)
                        return;

                    if (!ServerProps.NetworkisOK)
                    {
                        ServerProps.ServerisOnline = false;
                        Finalising();
                        return;
                    }

                    TcpClient client = serv.AcceptTcpClient();                
                     StarttoListen = Task.Run(() => StartListeningtoMessages(client));                    
                }               
            }


            catch (SocketException)
            {
                ServerShutDown();
                // another exit point in the case of exeption
                return;
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
                    //exit point for function in order to complete task  
                    if (!ServerProps.ServerisOnline)
                        return;

                    if(!ServerProps.NetworkisOK)
                    {
                        ServerProps.ServerisOnline = false;
                        Finalising();
                        return;
                    }
                }
                MessageData mData = (MessageData)bf.Deserialize(netStr);

            
                // Server handles each message according to its "Network Action" parameter
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
                        mData.action = NetworkAction.None;
                        break;

                    
                    case NetworkAction.Sendmessage:
                        publicmessage(mData, netStr);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.SendPrivateMessage:
                        PrivateMessage(mData, netStr);
                        mData.action = NetworkAction.None;

                        break;

                    case NetworkAction.RequestforListofUsers:
                        ListofUsersRequest( mData, netStr);
                        mData.action = NetworkAction.None;
                        break;


                    case NetworkAction.UserDisconnection:
                        UserData uData = mData.Userdat;

                        // Deleting of users from those lists costed a lot of troubles because of inconsistency of list sizes, so i decided to to replase them whith null's
                        ServerProps.listofUsersontheserver[mData.Userdat.Userid] = null;
                        ServerProps.StreamsofClients[mData.Userdat.Userid] = null;  
                                                                                        
                        Userdicsconnecter(mData, netStr, uData);
                        mData.action = NetworkAction.None;
                        break;


                    case NetworkAction.None:                      
                        break;
                        
                }
            }
            return;
        }





        public static void StopListening()

        {

            MessageData byebye = new MessageData();
            byebye.Textmessage = "\n Goodbye to Everyone \n You were disconnected ";
            byebye.action = NetworkAction.SeverDisconnection;
            NetworkStream ns = null;
            publicmessage(byebye, ns);


        }

        public static void Finalising()
        {
            ServerShutDown();
            //ServerProps.ServerisOnline = false;           
            server.Stop();
            server = null;
            

            ServerProps.listofUsersontheserver.Clear();
            ServerProps.StreamsofClients.Clear();
            ipandportvalidation -= ServerEventHandlers.IPandPortValidationHandler;
            connection -= ServerEventHandlers.ConnectionHandler;
            publicmessage -= ServerEventHandlers.PublicMessageHandler;
            ListofUsersRequest -= ServerEventHandlers.UserREquestHandler;
            Userdicsconnecter -= ServerEventHandlers.DisconnectUser;
            PrivateMessage -= ServerEventHandlers.PrivatemessageHandler;
            ServerEventHandlers.unexpectedUserDisconnection_fortheInterface -= ServerEventHandlers.UnexpectedDisconnectionHandler;

            if (StarttoListen != null && StarttoListen.IsCompleted)
                StarttoListen.Dispose();


        }

        }
    }

