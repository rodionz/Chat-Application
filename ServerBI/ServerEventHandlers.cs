﻿using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using CommonTypes;
using System.IO;
using System.Collections.Generic;

namespace ServerBI
{
    public class ServerEventHandlers
    {
      
        public static event Action<MessageData> newuserconnected;
        public static event Action<MessageData> messgesent;
        public static event Action<UserData> UserRemovalfromtheInterface;
        public static event Action<MessageData, NetworkStream, int> UserDisconnectedUnexpected;


        internal static void IPandPortValidationHandler( MessageData mData, NetworkStream nStr)

        {          
                BinaryFormatter bf = new BinaryFormatter();
                mData.listofUsers = ServerProps.listofUsersontheserver;
                bf.Serialize(nStr, mData);
                return;           
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

                    
                }

                // Unexpected Client Disconnection
                catch(IOException)
                {

                    UserDisconnectedUnexpected(mData, nstr, i);


                }
               
            }
            messgesent(mData);

        }






        internal static void UsersListRequestHandler( MessageData mData, NetworkStream nStr)
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            mData.listofUsers = new List<UserData>();
            foreach(UserData ud in ServerProps.listofUsersontheserver)
            {
                if (ud != null)
                    mData.listofUsers.Add(ud);
            }

            //mData.listofUsers = ServerProps.listofUsersontheserver;
            mData.action = NetworkAction.RequestforListofUsers;
            bf.Serialize(nStr, mData);
        }








    //Usuall Disconnection
        internal static void DisconnectUser(MessageData mData, NetworkStream nStr, UserData uData)
        {
           
            BinaryFormatter bf = new BinaryFormatter();
           

            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {
               mData.Textmessage =  mData.Userdat.Username + " was disconnected";

                if (ServerProps.StreamsofClients[i] != null)
                {
                    mData.action = NetworkAction.UserDisconnection;
                    NetworkStream netStream = ServerProps.StreamsofClients[i];
                    bf = new BinaryFormatter();
                   
                    bf.Serialize(netStream, mData);
                }
               
            }

            UserRemovalfromtheInterface(uData);
        }


        internal static  void UnexpectedDisconnectionHandler(MessageData mData, NetworkStream nStream, int index)
        {
            mData = new MessageData();
            UserData LostUser = ServerProps.listofUsersontheserver[index];
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                ServerProps.StreamsofClients[index].Close();
                ServerProps.StreamsofClients[index].Dispose();
            }

            catch { }
                            
            ServerProps.listofUsersontheserver[index] = null;
            ServerProps.StreamsofClients[index] = null;
            mData.Textmessage = LostUser.Username + " was disconnected";


            for (int x = 0; x < ServerProps.StreamsofClients.Count; x++)
            {
                if (ServerProps.StreamsofClients[x] != null)
                {
                    mData.action = NetworkAction.UserDisconnection;
                    NetworkStream _netStream = ServerProps.StreamsofClients[x];
                    bf = new BinaryFormatter();
                    bf.Serialize(_netStream, mData);
                }
            }

            UserRemovalfromtheInterface(LostUser);
        }




        internal static void PrivatemessageHandler(MessageData mData, NetworkStream nStream)
        {
          


            for (int i = 0; i < ServerProps.StreamsofClients.Count; i++)
            {

                try
                {
                    if (ServerProps.StreamsofClients[i] != null && mData.listofnamesforPrivateMessage.Contains(ServerProps.listofUsersontheserver[i].Username))
                    {
                        NetworkStream netStream = ServerProps.StreamsofClients[i];
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(netStream, mData);
                    }

                }
                catch(IOException)
                {

                    UserDisconnectedUnexpected(mData, nStream, i);

                }
            }
        }

    }
}
