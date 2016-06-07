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
         
                HistoryListbox.Items.Add(mymesdata.Textmessage);

            if (CurrentUsersListbox.InvokeRequired)
            {
                SetTextCallback stc = new SetTextCallback(NewUserEvenHandler);
                this.Invoke(stc, new object[] { mymesdata });

            }

            else
            {
                CurrentUsersListbox.Items.Add(mymesdata.Userdat.Username);
            }
        }

    

}
}
