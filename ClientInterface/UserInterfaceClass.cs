using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonTypes;
using ClientBL;
using System.Diagnostics;
using System.Drawing;


namespace ClientInterface
{
    public partial class UserInterfaceClass : Form
    {
        public UserInterfaceClass()
        {
            InitializeComponent();                     
        }


        static List<string> privatelist = new List<string>();

        MessageData MesData = new MessageData();

        SignIn registration = new SignIn();

        UserData uData;

        


        private void ColorChoosing_Click(object sender, EventArgs e)
        {
            
            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                uData.color = colorDialog1.Color;
                MesData.color = colorDialog1.Color;
                this.TextMessages.ForeColor = colorDialog1.Color;
                this.ChatrichTextBox.SelectionColor = colorDialog1.Color;

            }
        }

     

        private void ConnectToserverButton_Click(object sender, EventArgs e)
        {

         


            registration.ShowDialog();

            if (ClientInterfaceProps.UserIsValid)
            {

               
                sendmessageButton.Enabled = true;
                PrivateMessageButton.Enabled = true;
                ColorChoosing.Enabled = true;
              

                RedLightPanel.Visible = false;
                GreenLightPanel.Visible = true;
                ClientInterfaceProps.ResetBooleans();             
                uData = registration.new_user;
                this.Userlabel.Text = ClientInterfaceProps.uNmake;
                ConnectToserverButton.Enabled = false;
                DisconnectFromServerButton.Enabled = true;

              
                ClientInterfaceProps.ResetBooleans();
            }


            else
            {
              
               
                ClientInterfaceProps.ResetBooleans();

            }
        }
        private void sendmessageButton_Click(object sender, EventArgs e)
        {
            if (!ClientInterfaceProps.PrivateMessage)
            {
                MesData.Time = DateTime.Now;
                MesData.Textmessage = this.TextMessages.Text;
                MesData.Userdat = uData;
                MesData.action = NetworkAction.Sendmessage;
                string message = (MesData.Userdat.Username + " says: " + TextMessages.Text);             
                TextMessages.Clear();
                UserLogic.SendMessage(MesData);
            }

            else
            {
                 MesData.Time = DateTime.Now;
                MesData.Textmessage = this.TextMessages.Text;
                MesData.Userdat = uData;
                MesData.action = NetworkAction.SendPrivateMessage;
                string message = (MesData.Userdat.Username + " says: " + TextMessages.Text);
                ChatrichTextBox.SelectionColor = Color.Black;
                ChatrichTextBox.AppendText("\n\t You send private message: " + TextMessages.Text);
                TextMessages.Clear();
                MesData.listofnamesforPrivateMessage = privatelist;
                UserLogic.SendMessage(MesData);
                ClientInterfaceProps.PrivateMessage = false;
                PrivatecheckedListBox.ClearSelected();
                PrivatecheckedListBox.Visible = false;
                privatelist.Clear();
                PrivatecheckedListBox.Items.Clear();
            }



           
        }

     

        private void TextMessages_ForeColorChanged(object sender, EventArgs e)
        {
            uData.color = this.TextMessages.ForeColor;

        }

        private void DisconnectFromServerButton_Click(object sender, EventArgs e)
        {
            UserInterfaceDisconnection();
            ClientProps.UserisOnline = false;
            ClientProps.shutdown = true;     
            UserLogic.Disconnection(uData);
           

        }



        private void PrivateMessageButton_Click(object sender, EventArgs e)
        {
            if (!ClientInterfaceProps.PrivateMessage)
            {
                ClientInterfaceProps.PrivateMessage = true;
                MesData.action = NetworkAction.RequestforListofUsers;
                UserLogic.SendMessage(MesData);
                PrivatecheckedListBox.Visible = true;
                ClientInterfaceProps.MessageIsPrivate = true;
            }
            else
            {
                ClientInterfaceProps.PrivateMessage = false;
                PrivatecheckedListBox.ClearSelected();
                PrivatecheckedListBox.Visible = false;
                privatelist.Clear();
                PrivatecheckedListBox.Items.Clear();

            }
        }
        
     internal  void UserInterfaceDisconnection()

        {
            if (UserPanel.InvokeRequired)
            {
                Action stc = UserInterfaceDisconnection;
                this.Invoke(stc, new object[] { });
            }

            else
            {
                GreenLightPanel.Visible = false;
                RedLightPanel.Visible = true;
                ConnectToserverButton.Enabled = true;
                DisconnectFromServerButton.Enabled = false;
                sendmessageButton.Enabled = false;
                PrivateMessageButton.Enabled = false;
                ColorChoosing.Enabled = false;
             


                
            }
        }




 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rodionz");
        }

    
   

        private void PrivatecheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {


            if (privatelist.Contains(PrivatecheckedListBox.Text))
            {

                privatelist.Remove(PrivatecheckedListBox.Text);
            }

            else
            {
                privatelist.Add(PrivatecheckedListBox.Text);

            }
        }

        private void UserInterfaceClass_Load(object sender, EventArgs e)
        {
            /*In the case that previous sesiion was closes unexpectedly, we need to unsubcribe from events
              to avoid duplicate event shooting
             */
            UnsubscribeFromAllEvents();

            SubscibetoAllEvents();

        }

        private void UserInterfaceClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnsubscribeFromAllEvents();
           
        }

        private void UserInterfaceClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ClientProps.UserisOnline)
            {
               
                UserLogic.Disconnection(uData);
                ClientProps.UserisOnline = false;

            }
        }

        private void SubscibetoAllEvents()
        {
            UserLogic.NoConnectionWhithServerEvent += NoServerHandler;
            UserLogic.MessageRecieved += IncomingMessageHandler;
            UserLogic.ServerDisconnected += UserInterfaceDisconnection;
        }

        private void UnsubscribeFromAllEvents()
        {
          
            UserLogic.MessageRecieved -= IncomingMessageHandler;
            UserLogic.ServerDisconnected -= UserInterfaceDisconnection;
            UserLogic.NoConnectionWhithServerEvent -= NoServerHandler;
           
            
        }
    }
}
