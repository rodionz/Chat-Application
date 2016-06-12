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
        public delegate void ServerActivity(MessageData delMesData);
        public static event ServerActivity newuserconnected ;
        public static event ServerActivity messgesent;

        public static List<UserData> listofUsersontheserver;
        public static TcpClient client;
        public static NetworkStream netStream;
        public static   List<TcpClient> Clients = new List<TcpClient>();
        public static List<NetworkStream> StreamsofClients = new List<NetworkStream>();


 
        public static void ServerOnline(ServerData sData)
       
          {
            TcpListener server = new TcpListener( IPAddress.Parse(sData.IPadress), sData.Portnumber);
            ServerBoolsandStreams.ServerisOnline = true;            
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


                        mData.listofUsers = listofUsersontheserver;
                        bf.Serialize(netStr, mData);
                        //netStr.Close();
                        break;

                    case NetworkAction.Connection:
                        StreamsofClients.Add(netStr);
                        mData.Time = DateTime.Now;
                        mData.Textmessage = mData.Userdat.Username.ToString() + " Connected: ";
                        newuserconnected(mData);
                        mData.StreamIndex = StreamsofClients.Count;
                        listofUsersontheserver.Add(mData.Userdat);
                        mData.Userdat.Userid = listofUsersontheserver.Count;
                        bf.Serialize(netStr, mData);
                        //netStr.Close();
                        break;

                    //Messages
                    case NetworkAction.Sendmessage:
                        messgesent(mData);
                        bf.Serialize(netStr, mData);
                        //netStr.Close();
                        break;
                }


            }














        }

        public static void StopListening()

        {


        }

    }
}
