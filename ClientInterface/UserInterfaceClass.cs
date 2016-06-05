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
            //UserData.StaticlistofUsers
        }
        

        MessageData MesData = new MessageData();

        SignIn registration = new SignIn();

        UserData uData;

        //CommonTypes.UserData.StaticlistofUsers

        //public static UserData.List

        private void ColorChoosing_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                uData.Usercolor = colorDialog1.Color;
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
                uData.Ufont = fontDialog1.Font;
                this.TextMessages.Font = fontDialog1.Font;
            

            }
        }

        private void ConnectToserverButton_Click(object sender, EventArgs e)
        {

            if (ServerData.SERVERONLINE)
            {
                uData = new UserData(UserData.StaticlistofUsers.Count);

                registration.ShowDialog();
                if (ClientUiBooleans.UserIsValid)
                {
                    RedLightPanel.Visible = false;
                    GreenLightPanel.Visible = true;
                }
            }

            else
            {

                NoServersOnlineLabel.Text = "There are no availiable servers right now, please try again later, or start your server manually";


            }
        }
        private void sendmessageButton_Click(object sender, EventArgs e)
        {
            MesData.Dt = DateTime.Now;
            MesData.Messagecolor = this.TextMessages.ForeColor;
            MesData.Textmessage = this.TextMessages.Text;
            MesData.Userfont = this.TextMessages.Font;
            UserLogic.SendMessage(MesData);
        }

     

        private void TextMessages_FontChanged(object sender, EventArgs e)
        {
            uData.Usercolor = this.TextMessages.ForeColor;

            UserLogic.ColorwasChanged(uData);
        }

        private void TextMessages_ForeColorChanged(object sender, EventArgs e)
        {
            uData.Ufont = this.TextMessages.Font;
            UserLogic.FontwasChanged(uData);
        }
    }
}
