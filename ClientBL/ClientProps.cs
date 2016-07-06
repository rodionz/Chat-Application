using System;
using System.Collections.Generic;
using System.Net.Sockets;
using CommonTypes;

namespace ClientBL
{


    [Serializable]
   public class ClientProps
    {



       public static bool shutdown = false;

        public static List<UserData> listofUserfortheUsers;

        public static bool UserisOnline
        { get; set; }

              
         internal static  TcpClient LocalClient
        { get; set; }

       

        internal static NetworkStream clientStream
        { get; set; }
    }
}
