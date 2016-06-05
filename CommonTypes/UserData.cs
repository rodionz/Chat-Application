using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonTypes
{
    public class UserData
    {

        public string Username
        { get; set; }

       public Color Usercolor
        { get; set; }

        public int Userid
        { get; set; }

        public Font Ufont
        { get; set; }

        public string UserIP
        { get; set; }

        public int UserPort
        { get; set; }



        public UserData()
        {


        }

        public UserData(int numofuser)
        {
            this.Userid = numofuser;
        }

        public UserData(string IP, int PORT)
        {
            this.UserIP = IP;
            this.UserPort = PORT;
        }

      public  List<UserData> listofUsers;

        public static List<UserData> StaticlistofUsers;

        
    }
}
