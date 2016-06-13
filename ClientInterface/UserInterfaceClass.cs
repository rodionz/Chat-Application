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


namespace ClientInterface
{
    public partial class UserInterfaceClass : Form
    {
        public UserInterfaceClass()
        {
            InitializeComponent();
           
            
        }
        

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


            if (ClientBoolsandVariables.UserIsValid)
            {
                RedLightPanel.Visible = false;
                GreenLightPanel.Visible = true;
                ClientBoolsandVariables.ResetBooleans();             
                uData = registration.new_user;
                this.Userlabel.Text = ClientBoolsandVariables.uNmake;
            }


            else
            {

                NoServersOnlineLabel.Text = "There are no availiable servers right now, please try again later, or start your server manually";
                ClientBoolsandVariables.ResetBooleans();

            }
        }
        private void sendmessageButton_Click(object sender, EventArgs e)
        {
            MesData.Time = DateTime.Now;
            //MesData.color = this.TextMessages.ForeColor;
            MesData.Textmessage = this.TextMessages.Text;
            //MesData.font = this.TextMessages.Font;
            MesData.Userdat = uData;
            MesData.action = NetworkAction.Sendmessage;
            //UserLogic.MainClienFinction(MesData);
            //UserLogic.LockalmesData = MesData;
            //UserLogic.LolacAction = NetworkAction.Sendmessage;
            TextMessages.Clear();
            UserLogic.SendMessage(MesData);
        }

        private void TextMessages_FontChanged(object sender, EventArgs e)
        {
            uData.color = this.TextMessages.ForeColor;

            //UserLogic.ColorwasChanged(uData);
        }

        private void TextMessages_ForeColorChanged(object sender, EventArgs e)
        {
            uData.font = this.TextMessages.Font;
            //UserLogic.FontwasChanged(uData);
        }

        private void DisconnectFromServerButton_Click(object sender, EventArgs e)
        {
            ClientBoolsandStreams.UserisOnline = false;
        }

        private void UserInterfaceClass_Load(object sender, EventArgs e)
        {
            UserLogic.MessageRecieved += MessageHandler;
        }

        private void PrivateMessageButton_Click(object sender, EventArgs e)
        {
            MesData.action = NetworkAction.RequestforListofUsers;
            UserLogic.SendMessage(MesData);
        }
    }
}
