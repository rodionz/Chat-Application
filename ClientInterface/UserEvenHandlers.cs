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
using ClientBL;

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

            if (ChatrichTextBox.InvokeRequired)
            {
                LocalHandler messent = new LocalHandler(MessageHandler);
                this.Invoke(messent, new object[] { mData });
            }

            else
            {
                
                if (mData.action == NetworkAction.RequestforListofUsers)

                {
                    var names = from n in mData.listofUsers
                                select n.Username; 


                    for(int i = 0; i < mData.listofUsers.Count; i++)
                    {
                        //AllUsersCombobox.Items.Add(names.ToArray()[i]);
                        PrivatecheckedListBox.Items.Add(names.ToArray()[i]);

                    }
                       
                }

                else if (mData.action == NetworkAction.ConectionREsponse)
                {
                    //mData.listboxitem.Message = ("\n Server says: " + mData.Textmessage);
                    //ChatListBox.Items.Add(mData.listboxitem);
                    ChatrichTextBox.AppendText("\n Server says: " + mData.Textmessage);

                }

                else if (mData.action == NetworkAction.UserDisconnection)
                {
                    //mData.listboxitem.Message = ("Server says: " + mData.Textmessage);
                    //ChatListBox.Items.Add  ("\n Server says: "  +  mData.Textmessage);
                    ChatrichTextBox.AppendText("\n Server says: " + mData.Textmessage);

                }

                else if (mData.action == NetworkAction.SeverDisconnection)
                {
                    ChatrichTextBox.AppendText("\n Server says: " + mData.Textmessage);
                    //ClientProps.UserisOnline = false;
                    //GreenLightPanel.Visible = false;
                    //RedLightPanel.Visible = true;
                    //ConnectToserverButton.Enabled = true;
                    //DisconnectFromServerButton.Enabled = false;
                    //sendmessageButton.Enabled = false;
                    //PrivateMessageButton.Enabled = false;
                    //ColorChoosing.Enabled = false;
                    //changeFontButton.Enabled = false;
                }

                else
                {

                    ChatrichTextBox.SelectionColor = mData.color;
                    ChatrichTextBox.AppendText("\n" +mData.Userdat.Username + " says: " + mData.Textmessage);
                }
            }


        }

    }
}
