using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using CommonTypes;
using System.IO;

namespace ClientBL
{
   public class ClientBoolsandStreams
    {

        internal static bool UserisOnline
        { get; set; }

        internal static NetworkStream ClientStream
        { get; set; }
    }
}
