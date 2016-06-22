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

namespace ServerInterface
{

    public partial class ServerInterfaceClass : Form
    {

        delegate void LocalHandler(MessageData mdata);


        public  void NewUserEvenHandler(MessageData mymesdata)

        {
         
            if (CurrentUsersListbox.InvokeRequired || HistoryListbox.InvokeRequired)
            {
                LocalHandler stc = new LocalHandler(NewUserEvenHandler);
                this.Invoke(stc, new object[] { mymesdata });

            }

            else
            {
               // To change Port and IP!!!!
                CurrentUsersListbox.Items.Add(mymesdata.Userdat.Username +" IP: " + mymesdata.Userdat.IPadress + 
                    " Port: " + mymesdata.Userdat.Portnumber);
                HistoryListbox.Items.Add(mymesdata.Textmessage + mymesdata.Time.ToLongTimeString()  );
            }
        }

    
        public void MessagesentHandler(MessageData mData)
        {
            DateTime current = DateTime.Now;

            if (ChatListBox.InvokeRequired || CurrentUsersListbox.InvokeRequired || HistoryListbox.InvokeRequired )
            {
                LocalHandler messent = new LocalHandler(MessagesentHandler);
                this.Invoke(messent, new object[] { mData });
            }

            else
            {     if (mData.action == NetworkAction.ConectionREsponse)
                {
                    ChatListBox.Items.Add("Server says: " + mData.Textmessage);
                }

            // In the case of unexpected user disconnection
                   else if (mData.action == NetworkAction.UserDisconnection)
                {
                    ChatListBox.Items.Add("Server says: " + mData.Userdat.Username + " was disconnected");
                    CurrentUsersListbox.Items.RemoveAt(mData.Userdat.Userid);
                    HistoryListbox.Items.Add(mData.Userdat.Username + " was disconnected" + current.ToLongTimeString());
                }

                else
                {
                    ChatListBox.Items.Add(mData.Userdat.Username + " says: " + mData.Textmessage);
                }
            }
        }

        public  void NoServerHandler()
        {
            RedLightPanel.Visible = true;
            GreenLightPanel.Visible = false;
            StartServerButton.Enabled = true;
            StopServerButton.Enabled = false;
        }


        // For usual user disconnection
        public void DisconnectUserHAndler(MessageData mData)
        {
            if (CurrentUsersListbox.InvokeRequired || HistoryListbox.InvokeRequired)
            {
                LocalHandler messent = new LocalHandler(DisconnectUserHAndler);
                this.Invoke(messent, new object[] { mData });
            }


            else
            {
                DateTime current = DateTime.Now;
                //vat itemtoremove = from i in CurrentUsersListbox.Items
                //CurrentUsersListbox.Items.Remove()
                CurrentUsersListbox.Items.RemoveAt(mData.Userdat.Userid);
                HistoryListbox.Items.Add(mData.Userdat.Username + " was disconnected " + current.ToLongTimeString());
                ChatListBox.Items.Add("Server says: " + mData.Userdat.Username + " was disconnected " );

            }
            
        }

}
}
