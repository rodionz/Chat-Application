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
  public  class ServerBoolsandStreams
    {
         internal static bool  ServerisOnline
        { get; set; }



        internal static TcpClient LocalClient
        { get; set; }



        public static List<NetworkStream> StreamsofClients = new List<NetworkStream>();
    }
}
