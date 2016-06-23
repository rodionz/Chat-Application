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
            UserLogic.NoServer += UserInterfaceClass.NoServerHandler;
        }

        
        IPAddress clientIpAddr;
        public event EventHandler newUsercreated;
         internal   UserData new_user;
        MessageData mData;
        internal string userNIckname;
        internal string IPasString;
        internal int userPort;
        internal List<UserData> localListofUsers;
       
        
       
        

        private void ConfirmIP_Click(object sender, EventArgs e)
        {
            this.IPmaskedTextBox.ValidatingType = typeof(IPAddress);


            char[] delimit = { ' ' };
            string[] str = IPmaskedTextBox.Text.Split();
            string separator = "";
            IPasString = string.Join(separator, str);
            bool b = IPAddress.TryParse(IPasString, out clientIpAddr);


            
         bool portvalid = int.TryParse(portTextBox.Text, out userPort);

            if(!portvalid)
            {
                MessageBox.Show("Please Fill Number of Port and IPAdress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

           else if (!b)
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
                mData = new MessageData(new UserData(IPasString, userPort), NetworkAction.IpandPortValidaton);
               UserLogic.IPAndPortValidation(mData);


                if ( UserLogic.GlobalValidIpandPort)
                {
                    WarningLabel.ForeColor = Color.Lime;
                    WarningLabel.Text = "IP Adress and Port are Confirmed";
                    ConfirmIPandPort.Enabled = false;
                    localListofUsers = ClientProps.listofUserfortheUsers;
                    ClientInterfaceProps.IPandPortconfirmed = UserLogic.GlobalValidIpandPort;
                }

                else
                {
                    WarningLabel.ForeColor = Color.Red;
                    WarningLabel.Text = "Service is Unavavailble, please try another adress or port";
                }
               

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
            WarningLabel.Text = "";
            ConfirmIPandPort.Enabled = true;
            NickNameConfirmationLabel.Text = "";
            ConnectLabel.Text = "";
        }

     

        private void NicknameConfirmationButton_Click(object sender, EventArgs e)
        {


            if (ClientInterfaceProps.IPandPortconfirmed)
            {


                var listofnames = from n in localListofUsers
                                  select (n.Username);


                bool a = listofnames.Contains(UserNameBox.Text);

                if (UserNameBox.Text != "")
                {
                    if (!a)
                    {
                        NickNameConfirmationLabel.ForeColor = Color.Lime;
                        NickNameConfirmationLabel.Text = "UserName confirmed";
                        userNIckname = UserNameBox.Text;
                        ClientInterfaceProps.uNmake = userNIckname;
                        ClientInterfaceProps.NicnameConfirmed = true;
                    }

                    else
                    {
                        NickNameConfirmationLabel.ForeColor = Color.Red;
                        NickNameConfirmationLabel.Text = "UserName already take, please choose another one";


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
            if (ClientInterfaceProps.UserIsValid)
            {

                new_user = new UserData( IPasString, userPort, userNIckname);
                MessageData mData = new MessageData(new_user);
                mData.action = NetworkAction.Connection;
                UserLogic.LolacAction = NetworkAction.Connection;
                string message = "You Are Online Now";

                

                UserLogic.MainClienFinction(mData , new_user);
            
               
                ClearAll();
                Close();
            }

            else
            {
                ConnectLabel.ForeColor = Color.Red;
                ConnectLabel.Text = "You need to confirm IP, Por and UserName prior to connecting server";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPmaskedTextBox.Text = "127.000.000.001";
            portTextBox.Text = "60000";
            UserNameBox.Text = "Rodichek";
        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearAll();
        }
    }
}
