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

    


        public  void NewUserEvenHandler(MessageData mymesdata)
        {
            try
            {
                HistoryListbox.Items.Add(mymesdata.Textmessage);
                CurrentUsersListbox.Items.Add(mymesdata.Userdat.Username);
            }

            catch (InvalidOperationException IOE)
            {
                HistoryListbox.Items.Add(mymesdata.Textmessage);
                CurrentUsersListbox.Items.Add(mymesdata.Userdat.Username);

            }
        }

    

}
}
