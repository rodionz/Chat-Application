using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerInterface
{
   public static class ServerBools
    {
        public static bool PortValid;


        public static bool IPisVAlid;
      



        public static bool ServerisValid
        {

            get
            {
                if (PortValid && IPisVAlid)
                    return true;

                else
                    return false;

            }

            

        }



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

       public static void ResetBools()
        {

            PortValid = false;
            IPisVAlid = false;
            

        }

        public static bool WasPrinted;

    }
}
