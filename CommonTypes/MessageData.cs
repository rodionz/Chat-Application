using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonTypes
{
    [Serializable]
  public  class MessageData : CommonVariables



    {


        public string Textmessage
        { get; set; }


        public MessageData() { }

        public MessageData(UserData ud)
        {
            this.Userdat = ud;

        }
        
    }
}
