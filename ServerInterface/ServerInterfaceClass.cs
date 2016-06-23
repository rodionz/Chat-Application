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
using System.Diagnostics;


namespace ServerInterface
{
    public partial class ServerInterfaceClass : Form
    {
        public ServerInterfaceClass()
        {
            InitializeComponent();
            StopServerButton.Enabled = false;
            
        }


        ServerData sData = new ServerData();
        
      

        private void StartServerButton_Click(object sender, EventArgs e)
        {
           ServerEventHandlers.InterfaceDisconnecter += DisconnectUserHAndler;
            ServerLogic.NoServer += NoServerHandler;
            ServerLogic.ServerDisconnection += NoServerHandler;
            ServerConnection Sr = new ServerConnection(sData);
            Sr.ShowDialog();

            if (sData.IPadress != null && sData.Portnumber != 0)
            {
                RedLightPanel.Visible = false;
                GreenLightPanel.Visible = true;
                ServerLogic.ServerOnline(sData);
                StartServerButton.Enabled = false;
                StopServerButton.Enabled = true;
            }
                 
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

      

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            ServerLogic.StopListening();
            StartServerButton.Enabled = true;
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            ServerEventHandlers.InterfaceDisconnecter += DisconnectUserHAndler;
            ServerLogic.NoServer += NoServerHandler;
            RedLightPanel.Visible = false;
            GreenLightPanel.Visible = true;
            
            sData.IPadress = "127.0.0.1";
            sData.Portnumber = 60000;
            StopServerButton.Enabled = true;
            StartServerButton.Enabled = false;
            ServerLogic.ServerOnline(sData);
           
           
        }

        

       

        private void ServerInterfaceClass_Load(object sender, EventArgs e)
        {
            ServerEventHandlers.newuserconnected += NewUserEvenHandler;
            ServerEventHandlers.messgesent += MessagesentHandler;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rodionz");
        }

     

        private void ServerInterfaceClass_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
