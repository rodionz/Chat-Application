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
using ClientBL;
using System.Diagnostics;


namespace ClientInterface
{
    public partial class UserInterfaceClass : Form
    {
        public UserInterfaceClass()
        {
            InitializeComponent();
            DisconnectFromServerButton.Enabled = false;
                      
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

        private void changeFontButton_Click(object sender, EventArgs e)
        {
            fontDialog1.AllowScriptChange = true;
            fontDialog1.AllowSimulations = true;
            fontDialog1.ShowEffects = true;
          

            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                uData.font = fontDialog1.Font;
                MesData.font = fontDialog1.Font;
                this.TextMessages.Font = fontDialog1.Font;
            

            }
        }

        private void ConnectToserverButton_Click(object sender, EventArgs e)
        {
            registration.ShowDialog();


            if (ClientInterfaceProps.UserIsValid)
            {

                UserLogic.ServerDisconnected += Disconnection;
                sendmessageButton.Enabled = true;
                PrivateMessageButton.Enabled = true;
                ColorChoosing.Enabled = true;
                changeFontButton.Enabled = true;

                RedLightPanel.Visible = false;
                GreenLightPanel.Visible = true;
                ClientInterfaceProps.ResetBooleans();             
                uData = registration.new_user;
                this.Userlabel.Text = ClientInterfaceProps.uNmake;
                ConnectToserverButton.Enabled = false;
                DisconnectFromServerButton.Enabled = true;
                NoServersOnlineLabel.Text = "";


                UserLogic.MessageRecieved += MessageHandler;
            }


            else
            {

                NoServersOnlineLabel.Text = "There are no availiable servers right now, please try again later, or start your server manually";
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
                //MesData.listboxitem = new MyListboxItem(TextMessages.ForeColor, message, TextMessages.Font);
                TextMessages.Clear();
                UserLogic.SendMessage(MesData);
            }

            else
            {


                ClientInterfaceProps.PrivateMessage = false;
            }



           
        }

        private void TextMessages_FontChanged(object sender, EventArgs e)
        {
            uData.color = this.TextMessages.ForeColor;

        }

        private void TextMessages_ForeColorChanged(object sender, EventArgs e)
        {
            uData.font = this.TextMessages.Font;
           
        }

        private void DisconnectFromServerButton_Click(object sender, EventArgs e)
        {
            
            ClientProps.UserisOnline = false;
            UserLogic.DisconnectionEventHandler(new MessageData(uData), uData);
            UserLogic.NoServer -= UserInterfaceClass.NoServerHandler;
            UserLogic.MessageRecieved -= MessageHandler;
            Disconnection();

        }

       

        private void PrivateMessageButton_Click(object sender, EventArgs e)
        {
            ClientInterfaceProps.PrivateMessage = true;
            MesData.action = NetworkAction.RequestforListofUsers;
            UserLogic.SendMessage(MesData);
            PrivatecheckedListBox.Visible = true;
            ClientInterfaceProps.MessageIsPrivate = true;
        }

        
     internal void Disconnection()

        {
            if (panel1.InvokeRequired)
            {
                Action stc = Disconnection;
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
                changeFontButton.Enabled = false;
            }
        }




     

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rodionz");
        }

        private void UserInterfaceClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ClientProps.UserisOnline)
            {

                //MessageBox.Show("Please disconnect you client, before closing", "Client is connected", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //e.Cancel = true;

            }
        }

        //private void PrivatecheckedListBox_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    privatelist = new List<string>();
        //    privatelist.Add((string)PrivatecheckedListBox.SelectedItem);
        //}

        //private void PrivatecheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PrivatecheckedListBox.CheckOnClick = true;
        //    privatelist = new List<string>();
        //    privatelist.Add((string)PrivatecheckedListBox.SelectedItem);
        
        //}

        private void PrivatecheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            

            if (privatelist.Contains(PrivatecheckedListBox.CheckedItems.ToString()))
            {
                
                privatelist.Remove(PrivatecheckedListBox.CheckedItems.ToString());
            }

            else
            {
                privatelist.Add(PrivatecheckedListBox.CheckedItems.ToString());

            }
        }
    }
}
