using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInterface
{
   static class ClientBools
    {

       
        internal static bool UserIsValid
        {
            get
            {
                if (nicknameconfirmed && PortValid && ipandportconfirmed)
                    return true;
                else
                    return false;
            }
        }


        private static bool nicknameconfirmed = false;
        internal static bool NicnameConfirmed
        {
            get { return nicknameconfirmed; }

            set { nicknameconfirmed = value; }
        }


        internal static bool ipandportconfirmed = false;
        internal static bool IPandPortconfirmed
        {
            get { return ipandportconfirmed; }

            set { ipandportconfirmed = value; }
        }


       private static bool PortValid;

        public static bool PortisValid(this int num)
        {
            if (num > 10000 && num < 65535)
            {
                PortValid = true;
                return true;
            }
            else
            {
                PortValid = false;
                return false;
            }

        }






        public static void ResetBooleans()

        {

            
            nicknameconfirmed = false;
            ipandportconfirmed = false;
            PortValid = false;

        }




















    }
}
