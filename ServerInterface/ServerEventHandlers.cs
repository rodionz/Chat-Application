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

        delegate void SetTextCallback(MessageData mdata);


        public  void NewUserEvenHandler(MessageData mymesdata)

        {
         
                

            if (CurrentUsersListbox.InvokeRequired)
            {
                SetTextCallback stc = new SetTextCallback(NewUserEvenHandler);
                this.Invoke(stc, new object[] { mymesdata });

            }

            else
            {
                CurrentUsersListbox.Items.Add(mymesdata.Userdat.Username);
                HistoryListbox.Items.Add(mymesdata.Textmessage + mymesdata.Time.ToLongTimeString() );
            }
        }

    
        public void MessagesentHandler(MessageData mData)
        {
            if(ChatListBox.InvokeRequired)
            {
                SetTextCallback messent = new SetTextCallback(MessagesentHandler);
                this.Invoke(messent, new object[] { mData });
            }

            else
            {
                ChatListBox.Items.Add( mData.Userdat.Username.ToString()+ " says: " + mData.Textmessage);
            }
        }

}
}
