using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using CommonTypes;

namespace ServerBI
{
    public class ServerLogic
    {
      
        public static event Action NoServer;
        //public static event Action ServerDisconnection;            
        public static event Action<MessageData,NetworkStream>   ipandportvalidation;
        public static event Action<MessageData, NetworkStream> connection;
        public static event Action<MessageData, NetworkStream> publicmessage;
        public static event Action<MessageData, NetworkStream> ListofUsersRequest;
        public static event Action<MessageData, NetworkStream, UserData> Userdicsconnecter;      
        public static event Action<MessageData, NetworkStream> PrivateMessage;


        private static TcpListener server;
        private static Task mainTask;
        private static Task StarttoListen;

        public static void ServerOnline(ServerData sData)

        {
            try
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
            }

            catch
            {
                NoServer();
            }


            }

        public static void WaitingforNewConnections(TcpListener serv, NetworkAction NecAct)

        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();               
                serv.Start();

                while (ServerProps.ServerisOnline)
                {                  
                    TcpClient client = serv.AcceptTcpClient();                
                     StarttoListen = Task.Run(() => StartListeningtoMessages(client));
                }
            }
            catch 
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
                        mData.action = NetworkAction.None;
                        break;

                    //Messages
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
                        ServerProps.listofUsersontheserver[mData.Userdat.Userid] = null;
                        ServerProps.StreamsofClients[mData.Userdat.Userid] = null;                                                                  
                        Userdicsconnecter(mData, netStr, uData);
                        mData.action = NetworkAction.None;
                        break;


                    case NetworkAction.None:                      
                        break;
                        
                }
            }
        }





        public static void StopListening()

        {
           
            MessageData byebye = new MessageData();
            byebye.Textmessage = "\n Goodbye to Everyone \n You were disconnected ";
            byebye.action = NetworkAction.SeverDisconnection;
            NetworkStream ns = null;
            publicmessage(byebye, ns);
            NoServer();
            ServerProps.ServerisOnline = false;           
            server.Stop();

            ServerProps.listofUsersontheserver.Clear();
            ServerProps.StreamsofClients.Clear();

            ipandportvalidation -= ServerEventHandlers.IPandPortValidationHandler;
            connection -= ServerEventHandlers.ConnectionHandler;
            publicmessage -= ServerEventHandlers.PublicMessageHandler;
            ListofUsersRequest -= ServerEventHandlers.UserREquestHandler;
            Userdicsconnecter -= ServerEventHandlers.DisconnectUser;
            PrivateMessage -= ServerEventHandlers.PrivatemessageHandler;
            ServerEventHandlers.unexpectedUserDisconnection_fortheInterface -= ServerEventHandlers.UnexpectedDisconnectionHandler;
        }


        

    }
}
