using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    




    [Serializable]
     public abstract  class CommonVariables


    {

        


        public DateTime Time
        { get; set; }

        public Color color
        { get; set; }

        public UserData Userdat
        { get; set; }

        public Font font
        { get; set; }

        public string IPadress
        { get; set; }

        public int Portnumber
        { get; set; }

        public static ServerData CommonSd
        { get; set; }

        public string Username
        { get; set; }


        public List<UserData> listofUsers;

        
    }
}
