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
         
                

            if (CurrentUsersListbox.InvokeRequired)
            {
                LocalHandler stc = new LocalHandler(NewUserEvenHandler);
                this.Invoke(stc, new object[] { mymesdata });

            }

            else
            {
                //CurrentUsersListbox.ForeColor = mymesdata.color;
                //CurrentUsersListbox.Font = mymesdata.font;
                CurrentUsersListbox.Items.Add(mymesdata.Userdat.Username);
                HistoryListbox.Items.Add(mymesdata.Textmessage + mymesdata.Time.ToLongTimeString() );
            }
        }

    
        public void MessagesentHandler(MessageData mData)
        {
            if(ChatListBox.InvokeRequired)
            {
                LocalHandler messent = new LocalHandler(MessagesentHandler);
                this.Invoke(messent, new object[] { mData });
            }

            else
            {
               //ChatListBox.ForeColor = mData.color;
               // ChatListBox.Font = mData.font;
                ChatListBox.Items.Add( mData.Userdat.Username.ToString()+ " says: " + mData.Textmessage);
            }
        }

}
}
