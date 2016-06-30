using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using CommonTypes;

namespace ClientInterface
{
    public partial  class UserInterfaceClass : Form
    {

       

        public static void NoServerHandler(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public  void MessageHandler(MessageData mData)
        {

            if (ChatrichTextBox.InvokeRequired)
            {
                Action<MessageData> messent =MessageHandler;
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
                    
                    ChatrichTextBox.AppendText("Server says: " + mData.Textmessage + "\n");

                }

                else if (mData.action == NetworkAction.UserDisconnection)
                {
                  
                    ChatrichTextBox.AppendText("\n Server says: " + mData.Textmessage);

                }

                else if (mData.action == NetworkAction.SeverDisconnection)
                {
                    ChatrichTextBox.AppendText("\n Server says: " + mData.Textmessage);
             
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
