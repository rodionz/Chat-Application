using System.Collections.Generic;
using System.Net.Sockets;
using CommonTypes;
using System.Net.NetworkInformation;
using System.Net;

namespace ServerBI
{
    public  class ServerProps
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
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
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





















        public static bool  ServerisOnline
        { get; set; }
      

        public static List<UserData> listofUsersontheserver = new List<UserData>();

        public static List<NetworkStream> StreamsofClients = new List<NetworkStream>();

       
    }
}
