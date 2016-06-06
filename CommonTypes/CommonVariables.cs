using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
     public abstract  class CommonVariables
    {

        public string Textmessage
        { get; set; }

        public DateTime Dt
        { get; set; }

        public Color color
        { get; set; }

        public UserData Userdat
        { get; set; }

        public Font Userfont
        { get; set; }

        public string IPadress
        { get; set; }

        public int Portnumber
        { get; set; }

        public static ServerData CommonSd
        { get; set; }


        public string Username
        { get; set; }

       

        public int Userid
        { get; set; }

       

       // Attention!! Need to delet one

        public List<UserData> listofUsers;

        public static List<UserData> StaticlistofUsers;
    }
}
