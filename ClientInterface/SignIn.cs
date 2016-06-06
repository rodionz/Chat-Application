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
        MessageData mData;
        internal int userPort;
        

       
        

        private void ConfirmIP_Click(object sender, EventArgs e)
        {
            this.IPmaskedTextBox.ValidatingType = typeof(IPAddress);


            char[] delimit = { ' ' };
            string[] str = IPmaskedTextBox.Text.Split();
            string separator = "";
            string adress = string.Join(separator, str);
            bool b = IPAddress.TryParse(adress, out clientIpAddr);

         userPort = int.Parse(portTextBox.Text);

            if (!b)
            {
                WarningLabel.ForeColor = Color.Red;
                WarningLabel.Text = "Illigal IP, please enter IP adress in correct format";
            }

           else if(!userPort.PortisValid())
            {
                WarningLabel.ForeColor = Color.Red;
                WarningLabel.Text = "Port Number is Illigal \n Pelease choose port \n from 10000 to 65535";

            }

            else
            {
                mData = new MessageData() { Userdat = new UserData(adress, userPort) };
                bool ipandportvalid = UserLogic.IPAndPortValidation(mData);


                if (ipandportvalid)
                {
                    WarningLabel.ForeColor = Color.Lime;
                    WarningLabel.Text = "IP Adress and Port are Confirmed";
                    
                }

                else
                {
                    WarningLabel.ForeColor = Color.Red;
                    WarningLabel.Text = "Service is Unavavailble, please try another adress or port";
                }
                //IPconfirmationLabel.ForeColor = Color.Lime;
                // PortLabel.Text = "Port Confirmed";
                //ClientUiBooleans.PortValid = true;

            }
        
            
        }

        private void clearIP_Click(object sender, EventArgs e)
        {
            IPmaskedTextBox.Clear();
            WarningLabel.Text = "";
        }

        private void UsernameClearButton_Click(object sender, EventArgs e)
        {
            UserNameBox.Clear();
            WarningLabel.Text = "";
        }

        private void Clearportbutton_Click(object sender, EventArgs e)
        {
            portTextBox.Clear();
           
        }

        private void ClearAll()
        {
            IPmaskedTextBox.Clear();
            UserNameBox.Clear();
            portTextBox.Clear();
        }

     

        private void NicknameConfirmationButton_Click(object sender, EventArgs e)
        {


            if (ClientBools.IPandPortconfirmed)
            {


                var listofnames = from n in UserData.StaticlistofUsers
                                  select (n.Username);


                bool a = listofnames.Contains(UserNameBox.Text);

                if (UserNameBox.Text != "")
                {
                    if (!a)
                    {
                        WarningLabel.ForeColor = Color.Lime;
                        WarningLabel.Text = "UserName confirmed";
                        ClientBools.NicnameConfirmed = true;
                    }

                    else
                    {
                        WarningLabel.ForeColor = Color.Red;
                        WarningLabel.Text = "UserName already take, please choose another one";


                    }
                }

                else
                {
                    WarningLabel.ForeColor = Color.Red;
                    WarningLabel.Text = "Name is illigal";
                }

            }

            else
            {
                WarningLabel.ForeColor = Color.Red;
                WarningLabel.Text = "Please confiirm IP Adress and port before choosing Username";
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ClientBools.UserIsValid)
            {

                new_user = new UserData(UserData.StaticlistofUsers.Count) { Username = this.UserNameBox.Text, UserIP = clientIpAddr.ToString() };
                new_user.listofUsers.Add(new_user);
                //UserInterfaceClass.Statickist.Add(new UserData(UserInterfaceClass.Statickist.Count) { Username = this.UserNameBox.Text, UserIP = clientIpAddr.ToString() });
                //newUsercreated(this, NUEA);
                //new_user = UserInterfaceClass.ListofUsers.LastOrDefault();
                //new_user.listofUsers

                UserLogic.MainClienFinction( new_user);
            
                ClientBools.ResetBooleans();
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
