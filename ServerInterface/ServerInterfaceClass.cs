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
            ServerLogic.NoServer -= NoServerHandler;
            ServerEventHandlers.UsualUserDisconnection_forhteUnterface += DisconnectUserHAndler;
            ServerLogic.NoServer += NoServerHandler;
            //ServerLogic.ServerDisconnection += NoServerHandler;


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
            ServerProps.ServerisOnline = false;
            ServerEventHandlers.UsualUserDisconnection_forhteUnterface -= DisconnectUserHAndler;
            
            //ServerLogic.ServerDisconnection -= NoServerHandler;
            
            ServerLogic.StopListening();
            StartServerButton.Enabled = true;
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            ServerEventHandlers.UsualUserDisconnection_forhteUnterface += DisconnectUserHAndler;
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

     

      
    }
}
