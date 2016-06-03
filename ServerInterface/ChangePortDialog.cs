using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;


namespace ServerInterface
{
    public partial class ChangePortDialog : Form
    {
        public ChangePortDialog(ServerData sDat)
        {
            Sdata = sDat;
            InitializeComponent();
        }

        ServerData Sdata;

        public event EventHandler PortisChanged;
       

        private void PortConfirmationButtom_Click(object sender, EventArgs e)
        {
            int portnum = int.Parse(portTextBox.Text);

            if (portnum.PortisValid())
            {
                ServerBools.ResetBools();
                Sdata.PortofServer = portnum;
                 portConfirmLabel.ForeColor = Color.Lime;
                portConfirmLabel.Text = "Port is Valid";
                ////PortisChanged(this, Sdata);
                //Close();
            }

            else
            {
                portConfirmLabel.ForeColor = Color.Red;
                portConfirmLabel.Text = "Port Number is Illigal \n Pelease choose port from 10000 to 65535";

            }
        }

        private void Clearportbutton_Click(object sender, EventArgs e)
        {
            portTextBox.Clear();
            portConfirmLabel.Text = "";
        }
    }
}
