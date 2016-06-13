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


        internal static void ValidationHandler(NetworkStream net, MessageData mData)
        {
            NetworkStream netStream = ServerBoolsandStreams.LocalClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            mData.listofUsers = ServerLogic.listofUsersontheserver;
            bf.Serialize(netStream, mData);


        }


        internal static void ConnectionHandler(NetworkStream net, MessageData mData)
        {
            NetworkStream netStream = ServerBoolsandStreams.LocalClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            ServerBoolsandStreams.StreamsofClients.Add(netStream);
            mData.Time = DateTime.Now;
            mData.Textmessage = mData.Userdat.Username.ToString() + " Connected: ";
            newuserconnected(mData);
            mData.StreamIndex = ServerBoolsandStreams.StreamsofClients.Count;
           ServerLogic.listofUsersontheserver.Add(mData.Userdat);
            mData.Userdat.Userid =ServerLogic.listofUsersontheserver.Count;
            bf.Serialize(netStream, mData);

        }

        internal static void PublicMessageHandler(NetworkStream net, MessageData mData)
        {
            for (int i = 0; i < ServerBoolsandStreams.StreamsofClients.Count; i++)
            {
                NetworkStream netStream = ServerBoolsandStreams.StreamsofClients[i];
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(netStream, mData);
               
            }
            messgesent(mData);

        }

        internal static void PrivateMessageHandler(NetworkStream net, MessageData mData)
        {
            NetworkStream netStream = ServerBoolsandStreams.LocalClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            //mData.StreamsofClients = ServerBoolsandStreams.StreamsofClients;
            mData.listofUsers = ServerLogic.listofUsersontheserver;
            mData.action = NetworkAction.RequestforListofUsers;
            bf.Serialize(netStream, mData);
        }


    }
}
