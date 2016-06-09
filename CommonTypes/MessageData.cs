using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonTypes
{
    
   public enum ClientAction
    {IpandPortValidaton = 1, Connection = 2, Sendmessage= 3, ReceiveMesg = 4, None = 99}



    [Serializable]
  public  class MessageData : CommonVariables

    {


        public ClientAction action;


        public string Textmessage
        { get; set; }

       

        public MessageData() { }

        public MessageData(UserData ud)
        {
            this.Userdat = ud;

        }

        public MessageData(UserData ud, ClientAction act)
        {
            this.Userdat = ud;
            action = act;

        }
        
    }
}
