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
using ServerBI;

namespace ServerInterface
{
    public partial class ServerInterfaceClass : Form
    {
        public ServerInterfaceClass()
        {
            InitializeComponent();
            ServerLogic.newuserconnected += NewUserEvenHandler;

        }


        ServerData sData = new ServerData();

      

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            ServerConnection Sr = new ServerConnection(sData);
            Sr.ShowDialog();
            RedLightPanel.Visible = false;
            GreenLightPanel.Visible = true;


         


            ServerLogic.ServerOnline(sData);

         
            

           

        }

        private void ChangeIpButton_Click(object sender, EventArgs e)
        {

         

           
                ChangeIPDialog ChipDialog = new ChangeIPDialog(sData);

                ChipDialog.ShowDialog();
            
        }

        private void ChangePortButton_Click(object sender, EventArgs e)
        {
            ChangePortDialog Cpd = new ChangePortDialog(sData);

            Cpd.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            ServerLogic.StopListening();
        }

        private void tabChat_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RedLightPanel.Visible = false;
            GreenLightPanel.Visible = true;
            //ServerLogic.somethinghappend += PrintSomething;
            sData.IPadress = "127.0.0.1";
            sData.Portnumber = 60000;
          
            ServerLogic.ServerOnline(sData);
           
           
        }

        public void PrintSomething()
        {
           ChatListBox.Items.Add ( "Hello World");
        }
    }
}
