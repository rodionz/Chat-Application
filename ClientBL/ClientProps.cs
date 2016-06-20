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

 
    [Serializable]
   public class ClientProps
    {

        public static List<UserData> listofUserfortheUsers;

        public static bool UserisOnline
        { get; set; }

              
         internal static  TcpClient LocalClient
        { get; set; }

        //internal static int CurrentUserID
        //{ get; set; }
    }
}
