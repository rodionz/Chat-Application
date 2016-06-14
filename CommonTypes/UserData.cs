using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonTypes
{
    [Serializable]
    public class UserData : CommonVariables
    {

        public  int Userid
        { get; set; }

        public string Username
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
            this.IPadress = IP;
            this.Portnumber = PORT;
        }

        public UserData(int idofuser, string IP, int Port, string Username)
        {
            this.Userid = idofuser;
            this.IPadress = IP;
            this.Portnumber = Port;
            this.Username = Username;

        }

    

        
    }
}
