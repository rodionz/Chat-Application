using System.Collections.Generic;
using System.Net.Sockets;
using CommonTypes;



namespace ServerBI
{
    public  class ServerProps
    {
         internal static bool  ServerisOnline
        { get; set; }
      

        public static List<UserData> listofUsersontheserver = new List<UserData>();

        public static List<NetworkStream> StreamsofClients = new List<NetworkStream>();

       
    }
}
