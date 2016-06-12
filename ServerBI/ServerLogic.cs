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
       
        public delegate void ServerEvents(NetworkStream nStream, MessageData mData);


      
     
        public static event ServerEvents ipandportvalidation;
        public static event ServerEvents connection;
        public static event ServerEvents publicmessage;
        public static event ServerEvents privatemesage;






        public static List<UserData> listofUsersontheserver;        
      
       
      


 
        public static void ServerOnline(ServerData sData)
       
          {
            TcpListener server = new TcpListener( IPAddress.Parse(sData.IPadress), sData.Portnumber);
            ServerBoolsandStreams.ServerisOnline = true;
            ipandportvalidation += ServerEventHandlers.ValidationHandler;
            connection += ServerEventHandlers.ConnectionHandler;
            publicmessage += ServerEventHandlers.PublicMessageHandler;
            privatemesage += ServerEventHandlers.PrivateMessageHandler;         
            Task t1 = Task.Run(() => StartListening(server,NetworkAction.Connection));        
          }


        public static void StartListening(TcpListener serv, NetworkAction NecAct)

        {
            BinaryFormatter bf = new BinaryFormatter();
            listofUsersontheserver = new List<UserData>();
            serv.Start();

            while (ServerBoolsandStreams.ServerisOnline)
            {
              
               ServerBoolsandStreams.LocalClient = serv.AcceptTcpClient();              
                Task StarttoListen = Task.Run(() => StartListeningtoMessages());              
            }
        }                                                                                   
           

             
                   
                  




        private static void StartListeningtoMessages()
        {
            BinaryFormatter bf = new BinaryFormatter();
            NetworkStream netStr = ServerBoolsandStreams.LocalClient.GetStream();

            while (ServerBoolsandStreams.ServerisOnline)

            {

                while (!netStr.DataAvailable)
                {

                }
                MessageData mData = (MessageData)bf.Deserialize(netStr);

                switch (mData.action)

                {
                    case NetworkAction.IpandPortValidaton:
                        ipandportvalidation(netStr,mData);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.Connection:
                        connection(netStr,mData);
                        mData.action = NetworkAction.None;
                        break;

                    //Messages
                    case NetworkAction.Sendmessage:
                        publicmessage(netStr,mData);
                        mData.action = NetworkAction.None;
                        break;

                    case NetworkAction.SendPrivatemessage:
                        privatemesage(netStr, mData);
                        mData.action = NetworkAction.None;
                        break;
                        
                }


            }














        }

        public static void StopListening()

        {


        }

    }
}
