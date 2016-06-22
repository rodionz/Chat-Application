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
        public delegate void Server_ClientEvents(MessageData mData);
        public static event Server_ClientEvents newuserconnected;
        public static event Server_ClientEvents messgesent;
        public static event Server_ClientEvents InterfaceDisconnecter;
        


        internal static void ValidationHandler( MessageData mData, NetworkStream nStr)
        {          
            BinaryFormatter bf = new BinaryFormatter();
            mData.listofUsers = ServerProps.listofUsersontheserver;
            bf.Serialize(nStr, mData);
        }


        internal static void ConnectionHandler( MessageData mData, NetworkStream nStr)
        {
            mData.Userdat.Userid = ServerProps.StreamsofClients.Count;
            BinaryFormatter bf = new BinaryFormatter();
            ServerProps.StreamsofClients.Add(nStr);
            ServerProps.listofUsersontheserver.Add(mData.Userdat);            
            mData.Time = DateTime.Now;
            mData.Textmessage = mData.Userdat.Username.ToString() + " Connected ";
            newuserconnected(mData);
            mData.action = NetworkAction.ConectionREsponse;
  

        }

        internal static void PublicMessageHandler( MessageData mData, NetworkStream nstr)
        {
            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
                try
                {
                    if (ServerProps.StreamsofClients[i] != null)
                    {
                        NetworkStream netStream = ServerProps.StreamsofClients[i];
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(netStream, mData);
                    }

                    else
                        continue;
                }

                // Unexpected Client Disconnection
                catch(IOException)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    NetworkStream netStream = ServerProps.StreamsofClients[i];
                    UserData lostuser = ServerProps.listofUsersontheserver[i];
                    mData.Userdat = lostuser;
                    ServerProps.listofUsersontheserver.RemoveAt((mData.Userdat.Userid));
                    ServerProps.StreamsofClients.RemoveAt(mData.Userdat.Userid);                                  
                    mData.action = NetworkAction.UserDisconnection;
                 
                    for (int x = 0; x < ServerProps.StreamsofClients.Count; x++)
                    {
                        mData.Textmessage = mData.Userdat.Username + " was disconnected";
                        if (ServerProps.StreamsofClients[x] != null)
                        {
                            netStream = ServerProps.StreamsofClients[x];
                            bf.Serialize(netStream, mData);
                        }

                        else
                            continue;
                    }                    
                }
                continue;
            }
            messgesent(mData);

        }

        internal static void PrivateMessageHandler( MessageData mData, NetworkStream nStr)
        {
            
            BinaryFormatter bf = new BinaryFormatter(); 
            mData.listofUsers = ServerProps.listofUsersontheserver;
            mData.action = NetworkAction.RequestforListofUsers;
            bf.Serialize(nStr, mData);
        }


        internal static void DisconnectUser(MessageData mData, NetworkStream nStr)
        {
           
            BinaryFormatter bf = new BinaryFormatter();
           

            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
               mData.Textmessage =  mData.Userdat.Username + " was disconnected";

                if (ServerProps.StreamsofClients[i] != null)
                {
                    NetworkStream netStream = ServerProps.StreamsofClients[i];
                    bf = new BinaryFormatter();
                    bf.Serialize(netStream, mData);
                }
                else
                    continue;
            }

            InterfaceDisconnecter(mData);
        }



    }
}
