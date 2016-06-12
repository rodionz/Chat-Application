using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;

namespace ClientInterface
{
  public partial  class UserInterfaceClass : Form
    {

        delegate void LocalHandler(MessageData mdata);


        public static void NoServerHandler()
        {
            MessageBox.Show("Server is Offline", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        public  void MessageHandler(MessageData mData)
        {

            if (ChatListBox.InvokeRequired)
            {
                LocalHandler messent = new LocalHandler(MessageHandler);
                this.Invoke(messent, new object[] { mData });
            }

            else
            {
                ChatListBox.ForeColor = mData.color;
                ChatListBox.Font = mData.font;

                if (mData.action == NetworkAction.Connection)
                {
                    ChatListBox.Items.Add("You are online now");
                }

                else if (mData.action == NetworkAction.SendPrivatemessage)

                {
                    var names = from n in mData.listofUsers
                                select n.Username; 


                    for(int i = 0; i < mData.listofUsers.Count; i++)
                    {
                        listView1.Items.Add(names.ToArray()[i]);

                    }
                       

                }

                else
                {
                    ChatListBox.Items.Add(mData.Userdat.Username.ToString() + " says: " + mData.Textmessage);
                }
            }


        }

    }
}
