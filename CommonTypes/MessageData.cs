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
    public class MyListboxItem
    {
        public Color ItemColor
        { get; set; }

        public string Message
        { get; set; }

        public Font font
        { get; set; }

        public MyListboxItem(Color col, string mes, Font f)
        {
            ItemColor = col;
            Message = mes;
            font = f;
        }
            

    }


    [Serializable]
  public  class MessageData : CommonVariables

    {


        public MyListboxItem listboxitem;

        public List<NetworkStream> StreamsofClients;

        public NetworkAction action;


        public string Textmessage
        { get; set; }

       

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
