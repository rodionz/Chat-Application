using System;
using System.Drawing;
using System.Windows.Forms;
using CommonTypes;
using System.Net;
using ServerBI;

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
                Sdata.IPadress = adress;
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
            int portnum;
            bool p  = int.TryParse(portTextBox.Text, out portnum);

            if (p)
            {
                if (portnum.PortisValid())
                {
                    Sdata.Portnumber = portnum;
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

            else
            {
                portConfirmLabel.ForeColor = Color.Red;
                portConfirmLabel.Text = "Illigal input";
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

        private void ServerConnection_Load(object sender, EventArgs e)
        {
            ServerLogic.WrongIPorPort += ServerInterfaceClass.WrongIPandPOrthandler;
        }

        private void ServerConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
