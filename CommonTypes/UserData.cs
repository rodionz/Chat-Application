using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonTypes
{
    public class UserData : CommonVariables
    {

     


        public UserData()
        {


        }

        public UserData(int numofuser)
        {
            this.Userid = numofuser;
        }

        public UserData(string IP, int PORT)
        {
            this.IPadress = IP;
            this.Portnumber = PORT;
        }

      //public  List<UserData> listofUsers;

      //  public static List<UserData> StaticlistofUsers;

        
    }
}
