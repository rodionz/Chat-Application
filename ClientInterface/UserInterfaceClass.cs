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

namespace ClientInterface
{
    public partial class UserInterfaceClass : Form
    {
        public UserInterfaceClass()
        {
            InitializeComponent();
        }
        UserData uData = new UserData(1);

        MessageData MesData = new MessageData();

        SignIn registration = new SignIn();


       public static List<UserData> ListofUsers = new List<UserData>();

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
            registration.ShowDialog();
            if (ClientUiBooleans.UserIsValid)
            {
                RedLightPanel.Visible = false;
                GreenLightPanel.Visible = true;
            }
        }

        private void sendmessageButton_Click(object sender, EventArgs e)
        {
            MesData.Dt = DateTime.Now;
            //MesData.Messagecolor = 
            //MesData.Textmessage =
        }

     

        private void TextMessages_FontChanged(object sender, EventArgs e)
        {

        }

        private void TextMessages_ForeColorChanged(object sender, EventArgs e)
        {

        }
    }
}
