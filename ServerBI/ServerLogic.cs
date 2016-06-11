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
            ServerBools.ServerisOnline = true;            
            Task t1 = Task.Run(() => StartListening(server,NetworkAction.Connection));        
          }


        public static void StartListening(TcpListener serv, NetworkAction NecAct)

        {
            BinaryFormatter bf = new BinaryFormatter();
            listofUsersontheserver = new List<UserData>();           
             serv.Start();

            while (ServerBools.ServerisOnline)
            {
                Task<NetworkStream> AccepttonewClientsTAsk = Task<NetworkStream>.Factory.StartNew(() =>
                {

                    //while (true)
                    //{
                        TcpClient client = serv.AcceptTcpClient();
                        NetworkStream netStr = client.GetStream();
                    
                    return netStr;
                    //}

                });

                NetworkStream netStream = AccepttonewClientsTAsk.Result;


                                                                                            
           

                Task<MessageData> StartListeningtoMessages = Task<MessageData>.Factory.StartNew(() =>
                {
                    NecAct = NetworkAction.None;
                  

                    while (!netStream.DataAvailable)
                    {

                    }
                    MessageData messagData = (MessageData)bf.Deserialize(netStream);

                    return messagData;
                });

                MessageData mData = StartListeningtoMessages.Result; 
              

                switch (mData.action)

                {
                    case NetworkAction.IpandPortValidaton:


                        mData.listofUsers = listofUsersontheserver;
                        bf.Serialize(netStream, mData);
                        break;

                    case NetworkAction.Connection:
                        StreamsofClients.Add(netStream);
                        mData.Time = DateTime.Now;
                        mData.Textmessage = mData.Userdat.Username.ToString() + " Connected: ";                       
                        newuserconnected(mData);
                        mData.StreamIndex = StreamsofClients.Count;
                        listofUsersontheserver.Add(mData.Userdat);
                        bf.Serialize(netStream, mData);
                        break;

                    //Messages
                    case NetworkAction.Sendmessage:
                        messgesent(mData);
                        bf.Serialize(netStream, mData);
                        break;

                }

                //}
            }
        }

        private static void AcceptingnewClients(TcpListener serv)
        {
           
        }

        public static void StopListening()

        {


        }

    }
}
