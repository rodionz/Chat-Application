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
  public  class ServerProps
    {
         internal static bool  ServerisOnline
        { get; set; }



        internal static TcpClient LocalClient
        { get; set; }


        internal static NetworkStream LocalStream;

        public static List<UserData> listofUsersontheserver = new List<UserData>();


        //public static List<ServerData> serverData = new List<ServerData>();

        public static List<NetworkStream> StreamsofClients = new List<NetworkStream>();

       
    }
}
