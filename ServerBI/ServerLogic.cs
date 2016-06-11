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

        public static List<UserData> listofUsersontheserver = new List<UserData>();
        public static TcpClient client;
        NetworkStream netStream;
        //BinaryFormatter bf;
       




        public static void ServerOnline(ServerData sData)
       
          {
                      
            Task t1 = Task.Run(() => StartListening(sData));        
          }



        public static void StartListening(ServerData sData)

        {
            MessageData mData;
            TcpClient client;
            TcpListener server;
            NetworkStream netStream;
            server = new TcpListener(IPAddress.Parse(sData.IPadress), sData.Portnumber);
            server.Start();
             client = server.AcceptTcpClient();

            while(client.Connected)
            {
                netStream = client.GetStream();
             
                BinaryFormatter bFormatt = new BinaryFormatter();
                mData = (MessageData)bFormatt.Deserialize(netStream);
                
                switch(mData.action)
                {
                    case NetworkAction.IpandPortValidaton:
                        mData.listofUsers = listofUsersontheserver;
                        bFormatt.Serialize(netStream, mData);
                        mData.action = NetworkAction.None;
                       
                        break;


                


                }


            }

            ////TcpClient client = serv.AcceptTcpClient();

            ////TcpClient client = serv.AcceptTcpClient();
            //while (true)
            //{
            //    //TcpClient client = serv.AcceptTcpClient();
            //    TcpClient client = serv.AcceptTcpClient();
            //    //NecAct = NetworkAction.None;
            //    netStream = client.GetStream();
            //    bf = new BinaryFormatter();
            //    //TcpClient client = serv.AcceptTcpClient();
            //    mData = (MessageData)bf.Deserialize(netStream);

            //    switch (mData.action)

            //        {       // IP and Port Validation
            //            case NetworkAction.IpandPortValidaton:
            //            //netStream = client.GetStream();
            //             bf = new BinaryFormatter();
            //             //mData = (MessageData)bf.Deserialize(netStream);
            //            mData.listofUsers = listofUsersontheserver;
            //             bf.Serialize(netStream, mData);
            //            mData.action = NetworkAction.None;
            //            break;



            //            //User Connection
            //            case NetworkAction.Connection:
            //            bf = new BinaryFormatter();
            //            //netStream = client.GetStream();
            //            //mData = (MessageData)bf.Deserialize(netStream);
            //            mData.Time = DateTime.Now;
            //            mData.Textmessage = mData.Userdat.Username.ToString() + " Connected: ";
            //            //!!!!!!  Redo !!!!!
            //            newuserconnected(mData);
            //            listofUsersontheserver.Add(mData.Userdat);
            //            mData.action = NetworkAction.None;

            //            break;

            //            //Messages -recieve from user
            //            case NetworkAction.ReceiveMesg:
            //            netStream = client.GetStream();
            //            mData = (MessageData)bf.Deserialize(netStream);
            //            messgesent(mData);
            //            mData.action = NetworkAction.Sendmessage;
            //            break;

            //            //Messages - sent to users
            //            case NetworkAction.Sendmessage:
            //            bf = new BinaryFormatter();
            //            bf.Serialize(netStream, mData);
            //            mData.action = NetworkAction.None;
            //            break;

            //        case NetworkAction.None:
            //            break;



        }




                
            }
      

    }

