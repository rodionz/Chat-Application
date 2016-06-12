﻿namespace ServerInterface
{
    partial class ServerInterfaceClass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CurrentUsersListbox = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.HistoryListbox = new System.Windows.Forms.ListBox();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.ChatListBox = new System.Windows.Forms.ListBox();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.ChangeIpButton = new System.Windows.Forms.Button();
            this.ChangePortButton = new System.Windows.Forms.Button();
            this.GreenLightPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.GreenLamp = new System.Windows.Forms.PictureBox();
            this.RedLightPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RedLamp = new System.Windows.Forms.PictureBox();
            this.StopServerButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.GreenLightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).BeginInit();
            this.RedLightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Location = new System.Drawing.Point(248, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 326);
            this.panel1.TabIndex = 1;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabChat);
            this.tabControl2.Location = new System.Drawing.Point(23, 21);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(400, 274);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.CurrentUsersListbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(392, 248);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Current Users";
            // 
            // CurrentUsersListbox
            // 
            this.CurrentUsersListbox.FormattingEnabled = true;
            this.CurrentUsersListbox.Location = new System.Drawing.Point(18, 17);
            this.CurrentUsersListbox.Name = "CurrentUsersListbox";
            this.CurrentUsersListbox.Size = new System.Drawing.Size(368, 225);
            this.CurrentUsersListbox.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.Controls.Add(this.HistoryListbox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(392, 248);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "History";
            // 
            // HistoryListbox
            // 
            this.HistoryListbox.FormattingEnabled = true;
            this.HistoryListbox.Location = new System.Drawing.Point(20, 7);
            this.HistoryListbox.Name = "HistoryListbox";
            this.HistoryListbox.Size = new System.Drawing.Size(366, 238);
            this.HistoryListbox.TabIndex = 0;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.ChatListBox);
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(392, 248);
            this.tabChat.TabIndex = 2;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            this.tabChat.Click += new System.EventHandler(this.tabChat_Click);
            // 
            // ChatListBox
            // 
            this.ChatListBox.FormattingEnabled = true;
            this.ChatListBox.Location = new System.Drawing.Point(48, 17);
            this.ChatListBox.Name = "ChatListBox";
            this.ChatListBox.Size = new System.Drawing.Size(315, 212);
            this.ChatListBox.TabIndex = 0;
            // 
            // StartServerButton
            // 
            this.StartServerButton.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServerButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.StartServerButton.Location = new System.Drawing.Point(262, 431);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(121, 43);
            this.StartServerButton.TabIndex = 2;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // ChangeIpButton
            // 
            this.ChangeIpButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeIpButton.Location = new System.Drawing.Point(751, 71);
            this.ChangeIpButton.Name = "ChangeIpButton";
            this.ChangeIpButton.Size = new System.Drawing.Size(144, 43);
            this.ChangeIpButton.TabIndex = 3;
            this.ChangeIpButton.Text = "Change IP";
            this.ChangeIpButton.UseVisualStyleBackColor = true;
            this.ChangeIpButton.Click += new System.EventHandler(this.ChangeIpButton_Click);
            // 
            // ChangePortButton
            // 
            this.ChangePortButton.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePortButton.Location = new System.Drawing.Point(750, 133);
            this.ChangePortButton.Name = "ChangePortButton";
            this.ChangePortButton.Size = new System.Drawing.Size(145, 43);
            this.ChangePortButton.TabIndex = 4;
            this.ChangePortButton.Text = "Change Port";
            this.ChangePortButton.UseVisualStyleBackColor = true;
            this.ChangePortButton.Click += new System.EventHandler(this.ChangePortButton_Click);
            // 
            // GreenLightPanel
            // 
            this.GreenLightPanel.Controls.Add(this.label2);
            this.GreenLightPanel.Controls.Add(this.GreenLamp);
            this.GreenLightPanel.Location = new System.Drawing.Point(54, 185);
            this.GreenLightPanel.Name = "GreenLightPanel";
            this.GreenLightPanel.Size = new System.Drawing.Size(143, 76);
            this.GreenLightPanel.TabIndex = 18;
            this.GreenLightPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(5, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Server is Online";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // GreenLamp
            // 
            this.GreenLamp.Image = global::ServerInterface.Properties.Resources.green;
            this.GreenLamp.Location = new System.Drawing.Point(50, 3);
            this.GreenLamp.Name = "GreenLamp";
            this.GreenLamp.Size = new System.Drawing.Size(35, 35);
            this.GreenLamp.TabIndex = 14;
            this.GreenLamp.TabStop = false;
            // 
            // RedLightPanel
            // 
            this.RedLightPanel.Controls.Add(this.label1);
            this.RedLightPanel.Controls.Add(this.RedLamp);
            this.RedLightPanel.Location = new System.Drawing.Point(54, 71);
            this.RedLightPanel.Name = "RedLightPanel";
            this.RedLightPanel.Size = new System.Drawing.Size(143, 82);
            this.RedLightPanel.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Server is Offline";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RedLamp
            // 
            this.RedLamp.Image = global::ServerInterface.Properties.Resources.red;
            this.RedLamp.Location = new System.Drawing.Point(50, 3);
            this.RedLamp.Name = "RedLamp";
            this.RedLamp.Size = new System.Drawing.Size(35, 34);
            this.RedLamp.TabIndex = 13;
            this.RedLamp.TabStop = false;
            // 
            // StopServerButton
            // 
            this.StopServerButton.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopServerButton.ForeColor = System.Drawing.Color.Tomato;
            this.StopServerButton.Location = new System.Drawing.Point(578, 431);
            this.StopServerButton.Name = "StopServerButton";
            this.StopServerButton.Size = new System.Drawing.Size(118, 43);
            this.StopServerButton.TabIndex = 19;
            this.StopServerButton.Text = "Stop Server";
            this.StopServerButton.UseVisualStyleBackColor = true;
            this.StopServerButton.Click += new System.EventHandler(this.StopServerButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "MagicStart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 42);
            this.label3.TabIndex = 21;
            this.label3.Text = "Server";
            // 
            // ServerInterfaceClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1048, 568);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StopServerButton);
            this.Controls.Add(this.GreenLightPanel);
            this.Controls.Add(this.RedLightPanel);
            this.Controls.Add(this.ChangePortButton);
            this.Controls.Add(this.ChangeIpButton);
            this.Controls.Add(this.StartServerButton);
            this.Controls.Add(this.panel1);
            this.Name = "ServerInterfaceClass";
            this.Text = "ServerUi";
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.GreenLightPanel.ResumeLayout(false);
            this.GreenLightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).EndInit();
            this.RedLightPanel.ResumeLayout(false);
            this.RedLightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TabControl tabControl2;
        public System.Windows.Forms.TabPage tabPage4;
        public System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Button ChangeIpButton;
        private System.Windows.Forms.Button ChangePortButton;
        private System.Windows.Forms.Panel GreenLightPanel;
        private System.Windows.Forms.PictureBox GreenLamp;
        private System.Windows.Forms.Panel RedLightPanel;
        private System.Windows.Forms.PictureBox RedLamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StopServerButton;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox ChatListBox;
        internal System.Windows.Forms.ListBox CurrentUsersListbox;
        private System.Windows.Forms.ListBox HistoryListbox;
        private System.Windows.Forms.Label label3;
    }
}

