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
                if (NicnameConfirmed && PortValid && IPandPortconfirmed)
                    return true;
                else
                    return false;
            }
        }


        
        internal static bool NicnameConfirmed
        { get;set;}


       
        internal static bool IPandPortconfirmed
        { get; set; }
     


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


            NicnameConfirmed = false;
            IPandPortconfirmed = false;
            PortValid = false;

        }




















    }
}
