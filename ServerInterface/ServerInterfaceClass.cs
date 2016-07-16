using System;
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
            ServerLogic.ServerShutDown -= NoServerHandler;
           
            ServerLogic.ServerShutDown += NoServerHandler;
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

      

      

      

        private void StopServerButton_Click(object sender, EventArgs e)
        {
           
           /* ServerProps.ServerisOnline = false*/;
            ServerProps.ManualSidconnection = true;
            ServerLogic.StopListening();
            StartServerButton.Enabled = true;
            StopServerButton.Enabled = false;
            GreenLightPanel.Visible = false;
            RedLightPanel.Visible = true;
           
            
        }

    

  
        private void ServerInterfaceClass_Load(object sender, EventArgs e)
        {
            ServerEventHandlers.newuserconnected += NewUserEvenHandler;
            ServerEventHandlers.messgesent += MessagesentHandler;
            ServerEventHandlers.UserRemovalfromtheInterface += DisconnectUserHAndler;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/rodionz");
        }

        private void ServerInterfaceClass_FormClosing(object sender, FormClosingEventArgs e)

        {
                          
                ServerProps.ManualSidconnection = true;
                ServerLogic.StopListening();
          
        }

        private void ServerInterfaceClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            ServerEventHandlers.UserRemovalfromtheInterface -= DisconnectUserHAndler;
            //ServerLogic.ConnecionWhithWrongIPorPort -= ServerInterfaceClass.AtemmttoconnectWhithWrongIPandPort_Handler;
        }
    }
}
