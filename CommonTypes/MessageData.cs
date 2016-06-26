using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Sockets;

namespace CommonTypes
{


  


    [Serializable]
  public  class MessageData : CommonVariables

    {


        public UserData Userdat
        { get; set; }

        


        //public List<NetworkStream> StreamsofClients;

        public NetworkAction action;


        public string Textmessage
        { get; set; }

        public List<string> listofnamesforPrivateMessage;


        public List<UserData> listofUsers;

        public MessageData() { }

        public MessageData(UserData ud)
        {
            this.Userdat = ud;

        }

        public MessageData(UserData ud, NetworkAction act)
        {
            this.Userdat = ud;
            action = act;

        }
        
    }
}
