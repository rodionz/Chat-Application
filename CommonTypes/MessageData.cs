using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonTypes
{
  public  class MessageData
    {
        public string Textmessage
        { get; set; }

        public DateTime Dt
        { get; set; }

        public Color Messagecolor
        { get; set; }

        public UserData Userdat
        { get; set; }

        public Font Userfont
        { get; set; }


        /* 
        Using of List of UserDta objects inside of MessgageData class was intended. 
        It has been used when we validate User's IP and Port whith the server, server returns list of
        connected user, inside of MessageData object
    */
        public List<UserData> listofUsers;
    }
}
