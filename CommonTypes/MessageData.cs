using System;
using System.Collections.Generic;

namespace CommonTypes
{
    [Serializable]
  public  class MessageData : CommonVariables

    {


        public UserData Userdat
        { get; set; }
     
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
