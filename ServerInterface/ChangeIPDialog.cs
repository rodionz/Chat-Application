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
    public partial class ChangeIPDialog : Form
    {
        public ChangeIPDialog(ServerData sdatA)
        {
            serData = sdatA;
            InitializeComponent();
        }

        ServerData serData;
        IPAddress ServerIP;
        string adress;
        public event EventHandler IPisChanged;

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

                ServerBools.ResetBools();
                ipConfirmLabel.ForeColor = Color.Lime;
                ipConfirmLabel.Text = "IP is Valid";
                serData.IPofServer = adress;
                //IPisChanged(this, serData);
                //Close();
            }

            else
            {
                ipConfirmLabel.ForeColor = Color.Red;
                ipConfirmLabel.Text = "IP is Invalid, please try again";
            }
        }

        private void clearIP_Click(object sender, EventArgs e)
        {
            IPmaskedTextBox.Clear();
            ipConfirmLabel.Text = "";
        }

      
    }
}
