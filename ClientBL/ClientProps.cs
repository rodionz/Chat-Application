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
        I have Iwo functions that cheks is there any connection (both local and internet)
        at the present time
        Adn a third function that recieves parameters from those two function and return final result(True of False)
        I use same algorithm both on client side and server side
                     */



       internal static bool CheckForInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal static bool Network_Works = NetworkInterface.GetIsNetworkAvailable();


        internal static bool NetworkisOK

        {
            get

            {
                if (CheckForInternetConnection() && Network_Works)
                    return true;

                else
                    return false;
            }
        }







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
