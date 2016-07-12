using System;
using System.Collections.Generic;
using System.Net.Sockets;
using CommonTypes;
using System.Net.NetworkInformation;
using System.Net;

namespace ClientBL
{


    [Serializable]
   public class ClientProps
    {
        /* This is a only way i could find the solutioin
              for the "Network Cabel Disconnection" issue:
              I have Two functions that cheks is there any connection (both local and internet)
              at the present time
              Adn a third function that recieves parameters from those two function and return final result(True of False)
              I use same algorithm both on client side and server side.
                           */

        // This method was found on Stackoverflow. It checks if three is a internet connection availiable(including wifi)

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        public static bool CheckNet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }



        internal static bool Network_Works
        {
            get
            {
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                    return true;

                else
                    return false;

            }
        }


        internal static bool NetworkisOK

        {
            get

            {
                if (CheckNet() == true && Network_Works == true)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

///End of "Network cable disconnection" logic
/// //////////////////////////////////////////////////////////////////////////







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
