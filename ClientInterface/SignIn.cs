using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;
using ClientBL;

namespace ClientInterface
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        ServerData Sdata;
        IPAddress clientIpAddr;
        public event EventHandler newUsercreated;
        UserData new_user;

        //NewUserEventArgs NUEA = new NewUserEventArgs();


        private void ConfirmIP_Click(object sender, EventArgs e)
        {
            this.IPmaskedTextBox.ValidatingType = typeof(IPAddress);


            char[] delimit = { ' ' };
            string[] str = IPmaskedTextBox.Text.Split();
            string separator = "";
            string adress = string.Join(separator, str);
            bool b = IPAddress.TryParse(adress, out clientIpAddr);

            if (b == true)
            {
                //
                //ToChange IP
                //
                if (clientIpAddr.ToString() == "127.0.0.1")
                {
                   IPlabel.ForeColor = Color.Lime;
                   IPlabel.Text = "IP Confimed";
                    ClientUiBooleans.IPconfirmed = true;
                }

                else
                {
                    IPlabel.ForeColor = Color.Red;
                    IPlabel.Text = "IP was rejected by the server, please enter corect IP adress of the server ";

                }
            }
            else
            {
                IPlabel.ForeColor = Color.Red;
                IPlabel.Text = "Illigal IP, please enter IP adress in correct format";


            }

            
        }

        private void clearIP_Click(object sender, EventArgs e)
        {
            IPmaskedTextBox.Clear();
            IPlabel.Text = "";
        }

        private void UsernameClearButton_Click(object sender, EventArgs e)
        {
            UserNameBox.Clear();
            NameLabel.Text = "";
        }

        private void Clearportbutton_Click(object sender, EventArgs e)
        {
            portTextBox.Clear();
            PortLabel.Text = "";
        }

        private void ClearAll()
        {
            IPmaskedTextBox.Clear();
            UserNameBox.Clear();
            portTextBox.Clear();
        }

        private void PortConfirmationButtom_Click(object sender, EventArgs e)
        {
            //
            //ToChange port
            //



            if (portTextBox.Text == 6000.ToString())
            {
                PortLabel.ForeColor = Color.Lime;
               PortLabel.Text = "Port Confirmed";
                ClientUiBooleans.PORTconfirmed = true;

            }


            else

            {
               PortLabel.ForeColor = Color.Red;
                PortLabel.Text = "Port Denied, please try again.";


            }
        }

        private void NicknameConfirmationButton_Click(object sender, EventArgs e)
        {


            var listofnames = from n in UserInterfaceClass.ListofUsers
                              select (n.Username);


            bool a = listofnames.Contains(UserNameBox.Text);

            if (UserNameBox.Text != "")
            {
                if (!a)
                {
                    NameLabel.ForeColor = Color.Lime;
                    NameLabel.Text = "UserName confirmed";
                    ClientUiBooleans.NicnameConfirmed = true;
                }

                else
                {
                    NameLabel.ForeColor = Color.Red;
                    NameLabel.Text = "UserName already take, please choose another one";


                }
            }

            else
            {
                NameLabel.ForeColor = Color.Red;
                NameLabel.Text = "Name is illigal";
            }

        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ClientUiBooleans.UserIsValid)
            {

                new_user = new UserData(new_user.listofUsers.Count) { Username = this.UserNameBox.Text, UserIP = clientIpAddr.ToString() };
                new_user.listofUsers.Add(new_user);
                UserInterfaceClass.ListofUsers.Add(new UserData(UserInterfaceClass.ListofUsers.Count) { Username = this.UserNameBox.Text, UserIP = clientIpAddr.ToString() });
                //newUsercreated(this, NUEA);
                //new_user = UserInterfaceClass.ListofUsers.LastOrDefault();
                //new_user.listofUsers

                UserLogic.MainClienFinction( new_user);
            
                ClientUiBooleans.ResetBooleans();
                ClearAll();
                Close();
            }

            else
            {
                ConnectLabel.ForeColor = Color.Red;
                ConnectLabel.Text = "You need to confirm IP, Por and UserName prior to connecting server";

            }
        }

       
    }
}
