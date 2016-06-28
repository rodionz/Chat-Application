using System;



namespace ClientInterface
{


    static class ClientInterfaceProps

    {

        internal static string  uNmake;


        internal static bool PrivateMessage = false;
       
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



        internal static bool MessageIsPrivate;




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
