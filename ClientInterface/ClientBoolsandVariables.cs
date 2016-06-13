﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;
using ClientBL;

namespace ClientInterface
{

    //public class MyListboxItem
    //{
    //    public Color ItemColor
    //    { get; set; } 

    //    public string Message
    //    { get; set; }


    //}



   static class ClientBoolsandVariables
    {

        internal static bool DrawnewLine
        { get; set; }




        internal static string  uNmake;



       
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
