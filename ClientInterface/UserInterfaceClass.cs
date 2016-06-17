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

    
        

        MessageData MesData = new MessageData();

        SignIn registration = new SignIn();

        UserData uData;

        public static event EventHandler DrawItem;


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


            if (ClientInterfaceBool.UserIsValid)
            {
                RedLightPanel.Visible = false;
                GreenLightPanel.Visible = true;
                ClientInterfaceBool.ResetBooleans();             
                uData = registration.new_user;
                this.Userlabel.Text = ClientInterfaceBool.uNmake;
                ConnectToserverButton.Enabled = false;
                DisconnectFromServerButton.Enabled = true;
            }


            else
            {

                NoServersOnlineLabel.Text = "There are no availiable servers right now, please try again later, or start your server manually";
                ClientInterfaceBool.ResetBooleans();

            }
        }
        private void sendmessageButton_Click(object sender, EventArgs e)
        {
            if (!ClientInterfaceBool.PrivateMessage)
            {
                MesData.Time = DateTime.Now;
                MesData.Textmessage = this.TextMessages.Text;
                MesData.Userdat = uData;
                MesData.action = NetworkAction.Sendmessage;
                string message = (MesData.Userdat.Username + " says: " + TextMessages.Text);
                MesData.listboxitem = new MyListboxItem(TextMessages.ForeColor, message, TextMessages.Font);
                TextMessages.Clear();
                UserLogic.SendMessage(MesData);
            }

            else
            {


                ClientInterfaceBool.PrivateMessage = false;
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
            
            ClientLogicBools.UserisOnline = false;
            GreenLightPanel.Visible = false;
            RedLightPanel.Visible = true;
            ConnectToserverButton.Enabled = true;
            DisconnectFromServerButton.Enabled = false;
           
            
        }

        private void UserInterfaceClass_Load(object sender, EventArgs e)
        {
            UserLogic.MessageRecieved += MessageHandler;
        }

        private void PrivateMessageButton_Click(object sender, EventArgs e)
        {
            ClientInterfaceBool.PrivateMessage = true;
            MesData.action = NetworkAction.RequestforListofUsers;
            UserLogic.SendMessage(MesData);
            //AllUsersCombobox.Visible = true;
            PrivatecheckedListBox.Visible = true;
        }

        
     




        private void ChatListBox_DrawItem(object sender, DrawItemEventArgs e)
        {

                if (e.Index >= 0)
                {

                    MyListboxItem item = ChatListBox.Items[e.Index] as MyListboxItem;
                    if (item != null)
                    {
                        e.Graphics.DrawString(item.Message, item.font, new SolidBrush(item.ItemColor), 0, e.Index * ChatListBox.ItemHeight);
                        
                    }
                   
                }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rodionz");
        }

      

     
    }
}
