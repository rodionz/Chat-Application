using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInterface
{
    class ClientUiBooleans
    {

       
        internal static bool UserIsValid
        {
            get
            {
                if (nicknameconfirmed && portconfirmed && ipconfirmed)
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


        internal static bool ipconfirmed = false;
        internal static bool IPconfirmed
        {
            get { return ipconfirmed; }

            set { ipconfirmed = value; }
        }



        internal static bool portconfirmed = false;
        internal static bool PORTconfirmed
        {
            get { return portconfirmed; }
            set { portconfirmed = value; }

        }


        public static void ResetBooleans()

        {

            
            nicknameconfirmed = false;
            ipconfirmed = false;
            portconfirmed = false;

        }




















    }
}
