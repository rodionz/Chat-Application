using System.Collections.Generic;
using System.Net.Sockets;
using CommonTypes;
using System.Net.NetworkInformation;
using System.Net;
using System;

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


         amendmend: i stoped to use CheckForInternetConnection() function, because of frequent Web Exeptions's. I guess mi IP was banned there
         because of multyply connection attempts
        
                     */



        internal static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }

            }

            catch (WebException WE)
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.cnn.com"))
                    {
                        return true;
                    }
                }
            }

            catch (Exception e)
            {
                return false;
            }
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
                if (CheckForInternetConnection() == true || Network_Works == true)
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
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool  ServerisOnline
        { get; set; }

        public static bool ManualSidconnection;

        public static List<UserData> listofUsersontheserver = new List<UserData>();

        public static List<NetworkStream> StreamsofClients = new List<NetworkStream>();

       
    }
}
