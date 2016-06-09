using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{

    public enum NetworkAction
    { IpandPortValidaton = 1, Connection = 2, Sendmessage = 3, ReceiveMesg = 4, None = 99 }



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
