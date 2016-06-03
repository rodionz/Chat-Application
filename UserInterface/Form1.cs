using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserData;
using ServerData;

namespace UserInterface
{
    public partial class Form1 : Form
    {


        Server servak = new Server();
        User localuser = new User();
        //ClientInterface.Text = new_user;
        SignIn signinForm = new SignIn();

        public Form1()
        {



            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            //signinForm.ShowDialog();
        }




        private void ColorChoosing_Click(object sender, EventArgs e)
        {

            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {

                this.TextMessages.ForeColor = colorDialog1.Color;
            }
        }



        private void ClientInterface_Enter(object sender, EventArgs e)
        {
            if (signinForm.new_user != null)
            {
                localuser = signinForm.new_user;
                ClientInterface.Text = localuser.Nickname;

            }
        }

        private void changeFontButton_Click(object sender, EventArgs e)
        {


            fontDialog1.AllowScriptChange = true;
            fontDialog1.AllowSimulations = true;
            fontDialog1.ShowEffects = true;
           
            DialogResult result = fontDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                this.TextMessages.Font = fontDialog1.Font;

            }
        }

        private void addclient2button_Click(object sender, EventArgs e)
        {
            Client2 = ClientInterface;
        }
    }
}
