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
   public class ServerEventHandlers
    {
        public delegate void ServerActivity(MessageData delMesData);
        public static event ServerActivity newuserconnected;
        public static event ServerActivity messgesent;
        //public static event ServerActivity unexpectedDisconnection;


        internal static void ValidationHandler( MessageData mData, NetworkStream nStr)
        {
            //NetworkStream nStr = mData.Userdat.userStream;
            BinaryFormatter bf = new BinaryFormatter();
            mData.listofUsers = ServerProps.listofUsersontheserver;
            bf.Serialize(nStr, mData);


        }


        internal static void ConnectionHandler( MessageData mData, NetworkStream nStr)
        {

            //unexpectedDisconnection += DisconnectUser;

            //NetworkStream netStream = mData.Userdat.userStream;
            BinaryFormatter bf = new BinaryFormatter();
            ServerProps.StreamsofClients.Add(nStr);
            mData.Time = DateTime.Now;
            mData.Textmessage = mData.Userdat.Username.ToString() + " Connected ";
            newuserconnected(mData);
            mData.StreamIndex = ServerProps.StreamsofClients.Count;
            ServerProps.listofUsersontheserver.Add(mData.Userdat);
            //mData.Userdat.Userid =ServerLogic.listofUsersontheserver.Count;
            mData.action = NetworkAction.ConectionREsponse;
            //bf.Serialize(netStream, mData);

        }

        internal static void PublicMessageHandler( MessageData mData, NetworkStream nstr)
        {
            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
                try
                {
                    NetworkStream netStream = ServerProps.StreamsofClients[i];
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(nstr, mData);
                }
                catch(IOException)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    NetworkStream netStream = ServerProps.StreamsofClients[i];
                    UserData lostuser = ServerProps.listofUsersontheserver[i];
                    mData.Userdat = lostuser;

                    ServerProps.listofUsersontheserver.RemoveAt((mData.Userdat.Userid));
                    ServerProps.StreamsofClients.RemoveAt(mData.Userdat.Userid);
                  
                    

                    mData.action = NetworkAction.UserDisconnection;
                    //unexpectedDisconnection(mData);
                    for (int x = 0; x < ServerProps.StreamsofClients.Count; x++)
                    {
                        mData.Textmessage = mData.Userdat.Username + " was disconnected";
                        netStream = ServerProps.StreamsofClients[x];
                      
                        bf.Serialize(netStream, mData);

                    }

                    ServerLogic.IdsAdjuction();


                }
            }
            messgesent(mData);

        }

        internal static void PrivateMessageHandler( MessageData mData, NetworkStream nStr)
        {
            //NetworkStream netStream = mData.Userdat.userStream;
            BinaryFormatter bf = new BinaryFormatter();
            //mData.StreamsofClients = ServerBoolsandStreams.StreamsofClients;
            mData.listofUsers = ServerProps.listofUsersontheserver;
            mData.action = NetworkAction.RequestforListofUsers;
            bf.Serialize(nStr, mData);
        }


        internal static void DisconnectUser(MessageData mData, NetworkStream nStr)
        {
            //NetworkStream netStream = mData.Userdat.userStream;
            BinaryFormatter bf = new BinaryFormatter();

            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
                mData.Textmessage =  mData.Userdat.Username + " was disconnected"; 
               NetworkStream netStream = ServerProps.StreamsofClients[i];
                 bf = new BinaryFormatter();
                bf.Serialize(netStream, mData);

            }


        }



    }
}
