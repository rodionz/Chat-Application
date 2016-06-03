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
using System.Net;

namespace ServerInterface
{
    public partial class ServerConnection : Form
    {
        public ServerConnection(ServerData sdat)
        {
            Sdata = sdat;
            InitializeComponent();
        }

        ServerData Sdata;
        IPAddress ServerIP;
        string adress;
       

        private void ConfirmIP_Click(object sender, EventArgs e)
        {
            this.IPmaskedTextBox.ValidatingType = typeof(IPAddress);
            char[] delimit = { ' ' };
            string[] str = IPmaskedTextBox.Text.Split();
            string separator = "";
             adress = string.Join(separator, str);
            bool b = IPAddress.TryParse(adress, out ServerIP);

            if (b)
            {
                Sdata.IPofServer = adress;
                 ipConfirmLabel.ForeColor = Color.Lime;
                ipConfirmLabel.Text = "IP is Valid";
                ServerBools.IPisVAlid = true;
            }

            else
            {
                ipConfirmLabel.ForeColor = Color.Red;
                ipConfirmLabel.Text = "IP is Invalid, please try again";
            }
        }

        private void PortConfirmationButtom_Click(object sender, EventArgs e)
        {
            int portnum = int.Parse(portTextBox.Text);

            if (portnum.PortisValid())
            {
                Sdata.PortofServer = portnum;
                portConfirmLabel.ForeColor = Color.Lime;
                portConfirmLabel.Text = "Port is Valid";
                ServerBools.PortValid = true;
            }

            else
            {
                portConfirmLabel.ForeColor = Color.Red;
                portConfirmLabel.Text = "Port Number is Illigal \n Pelease choose port \n from 10000 to 65535";

            }

        }

        private void CreateServerButton_Click(object sender, EventArgs e)
        {
            if(ServerBools.ServerisValid)
            Close();

            else
            {
                ServerCreationError.Text = "Please confirm IP Adress and Port Before Creating Server";
            }
        }

        private void clearIP_Click(object sender, EventArgs e)
        {
            ipConfirmLabel.Text = "";
            IPmaskedTextBox.Clear();
        }

        private void Clearportbutton_Click(object sender, EventArgs e)
        {
            portConfirmLabel.Text = "";
            portTextBox.Clear();
        }

      
    }
}
