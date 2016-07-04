using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using CommonTypes;

namespace ClientInterface
{
    public partial  class UserInterfaceClass : Form
    {

       

        public static void NoServerHandler(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public  void IncomingMessageHandler(MessageData mData)
        {

            if (ChatrichTextBox.InvokeRequired)
            {
                Action<MessageData> messent = IncomingMessageHandler;
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
                    
                        PrivatecheckedListBox.Items.Add(names.ToArray()[i]);

                    }
                       
                }

                else if (mData.action == NetworkAction.ConectionREsponse)
                {
                    ChatrichTextBox.AppendText("Server says: ");
                    ChatrichTextBox.SelectionColor = Color.Green;
                    ChatrichTextBox.AppendText( mData.Textmessage + "\n");
               

                }

                else if (mData.action == NetworkAction.UserDisconnection)
                {
                    ChatrichTextBox.AppendText("\n Server says: ");
                    ChatrichTextBox.SelectionColor = Color.Red;
                    ChatrichTextBox.AppendText(mData.Textmessage);
                    

                }

                else if (mData.action == NetworkAction.SeverDisconnection)
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n Server says: ");
                    ChatrichTextBox.SelectionColor = Color.Red;
                    ChatrichTextBox.AppendText(mData.Textmessage + "\n");
                    ChatrichTextBox.SelectionColor = Color.Black;
                }

                else
                {
                    ChatrichTextBox.SelectionColor = Color.Black;
                    ChatrichTextBox.AppendText("\n" + mData.Userdat.Username + " says: ");
                    ChatrichTextBox.SelectionColor = mData.color;
                    ChatrichTextBox.AppendText(mData.Textmessage);
                    ChatrichTextBox.SelectionColor = Color.Black;
                }
            }


        }

    }
}
