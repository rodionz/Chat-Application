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


        internal static void ValidationHandler( MessageData mData)
        {
            NetworkStream netStream = ServerBoolsandStreams.LocalClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            mData.listofUsers = ServerLogic.listofUsersontheserver;
            bf.Serialize(netStream, mData);


        }


        internal static void ConnectionHandler( MessageData mData)
        {
            NetworkStream netStream = ServerBoolsandStreams.LocalClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            ServerBoolsandStreams.StreamsofClients.Add(netStream);
            mData.Time = DateTime.Now;
            mData.Textmessage = mData.Userdat.Username.ToString() + " Connected ";
            newuserconnected(mData);
            mData.StreamIndex = ServerBoolsandStreams.StreamsofClients.Count;
           ServerLogic.listofUsersontheserver.Add(mData.Userdat);
            mData.Userdat.Userid =ServerLogic.listofUsersontheserver.Count;
            mData.action = NetworkAction.ConectionREsponse;
            //bf.Serialize(netStream, mData);

        }

        internal static void PublicMessageHandler( MessageData mData)
        {
            for (int i = 0; i < ServerBoolsandStreams.StreamsofClients.Count; i++)
            {
                NetworkStream netStream = ServerBoolsandStreams.StreamsofClients[i];
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(netStream, mData);
               
            }
            messgesent(mData);

        }

        internal static void PrivateMessageHandler( MessageData mData)
        {
            NetworkStream netStream = ServerBoolsandStreams.LocalClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            //mData.StreamsofClients = ServerBoolsandStreams.StreamsofClients;
            mData.listofUsers = ServerLogic.listofUsersontheserver;
            mData.action = NetworkAction.RequestforListofUsers;
            bf.Serialize(netStream, mData);
        }


        internal static void DisconnectUser(MessageData mData)
        {
            NetworkStream netStream = ServerBoolsandStreams.LocalClient.GetStream();
            BinaryFormatter bf = new BinaryFormatter();

            for (int i = 0; i < ServerBoolsandStreams.StreamsofClients.Count; i++)
            {
                mData.Textmessage = mData.Userdat.Username + " was dosconnected"; 
                netStream = ServerBoolsandStreams.StreamsofClients[i];
                 bf = new BinaryFormatter();
                bf.Serialize(netStream, mData);

            }


        }



    }
}
