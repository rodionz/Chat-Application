using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
   public class ServerData 
    {

        public string IPofServer
        { get; set; }

        public int PortofServer
        { get; set; }


       public static ServerData CommonSd
        { get; set; }

        public static bool SERVERONLINE
        {
            get
            {
                if (CommonSd.IPofServer != null && CommonSd.PortofServer != 0)
                    return true;

                else
                    return false;



            }


        }

        

        public static bool ServerOnlineFunc()
        {


            return false;
        }

    }
}
