namespace ClientInterface
{
    partial class UserInterfaceClass
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.ChatListBox = new System.Windows.Forms.ListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.User1Label = new System.Windows.Forms.Label();
            this.SendtoLabel = new System.Windows.Forms.Label();
            this.TextMessages = new System.Windows.Forms.TextBox();
            this.sendmessageButton = new System.Windows.Forms.Button();
            this.changeFontButton = new System.Windows.Forms.Button();
            this.ColorChoosing = new System.Windows.Forms.Button();
            this.ConnectToserverButton = new System.Windows.Forms.Button();
            this.DisconnectFromServerButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.RedLightPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.GreenLightPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.NoServersOnlineLabel = new System.Windows.Forms.Label();
            this.PrivateMessageButton = new System.Windows.Forms.Button();
            this.Userlabel = new System.Windows.Forms.Label();
            this.AllUsersCombobox = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GreenLamp = new System.Windows.Forms.PictureBox();
            this.RedLamp = new System.Windows.Forms.PictureBox();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.RedLightPanel.SuspendLayout();
            this.GreenLightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel5.Controls.Add(this.ChatListBox);
            this.panel5.Location = new System.Drawing.Point(205, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(397, 235);
            this.panel5.TabIndex = 3;
            // 
            // ChatListBox
            // 
            this.ChatListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ChatListBox.FormattingEnabled = true;
            this.ChatListBox.Location = new System.Drawing.Point(23, 16);
            this.ChatListBox.Name = "ChatListBox";
            this.ChatListBox.Size = new System.Drawing.Size(351, 199);
            this.ChatListBox.TabIndex = 0;
            this.ChatListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ChatListBox_DrawItem);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel6.Controls.Add(this.User1Label);
            this.panel6.Controls.Add(this.SendtoLabel);
            this.panel6.Controls.Add(this.TextMessages);
            this.panel6.Location = new System.Drawing.Point(205, 282);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(397, 88);
            this.panel6.TabIndex = 4;
            // 
            // User1Label
            // 
            this.User1Label.AutoSize = true;
            this.User1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User1Label.Location = new System.Drawing.Point(69, 11);
            this.User1Label.Name = "User1Label";
            this.User1Label.Size = new System.Drawing.Size(23, 16);
            this.User1Label.TabIndex = 2;
            this.User1Label.Text = "All";
            // 
            // SendtoLabel
            // 
            this.SendtoLabel.AutoSize = true;
            this.SendtoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendtoLabel.Location = new System.Drawing.Point(3, 8);
            this.SendtoLabel.Name = "SendtoLabel";
            this.SendtoLabel.Size = new System.Drawing.Size(65, 20);
            this.SendtoLabel.TabIndex = 1;
            this.SendtoLabel.Text = "Sent to:";
            // 
            // TextMessages
            // 
            this.TextMessages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TextMessages.Location = new System.Drawing.Point(23, 36);
            this.TextMessages.Multiline = true;
            this.TextMessages.Name = "TextMessages";
            this.TextMessages.Size = new System.Drawing.Size(351, 39);
            this.TextMessages.TabIndex = 0;
            this.TextMessages.FontChanged += new System.EventHandler(this.TextMessages_FontChanged);
            this.TextMessages.ForeColorChanged += new System.EventHandler(this.TextMessages_ForeColorChanged);
            // 
            // sendmessageButton
            // 
            this.sendmessageButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendmessageButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.sendmessageButton.Location = new System.Drawing.Point(640, 318);
            this.sendmessageButton.Name = "sendmessageButton";
            this.sendmessageButton.Size = new System.Drawing.Size(100, 39);
            this.sendmessageButton.TabIndex = 8;
            this.sendmessageButton.Text = "SEND";
            this.sendmessageButton.UseVisualStyleBackColor = true;
            this.sendmessageButton.Click += new System.EventHandler(this.sendmessageButton_Click);
            // 
            // changeFontButton
            // 
            this.changeFontButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeFontButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.changeFontButton.Location = new System.Drawing.Point(672, 116);
            this.changeFontButton.Name = "changeFontButton";
            this.changeFontButton.Size = new System.Drawing.Size(169, 36);
            this.changeFontButton.TabIndex = 10;
            this.changeFontButton.Text = "Change Font";
            this.changeFontButton.UseVisualStyleBackColor = true;
            this.changeFontButton.Click += new System.EventHandler(this.changeFontButton_Click);
            // 
            // ColorChoosing
            // 
            this.ColorChoosing.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorChoosing.ForeColor = System.Drawing.Color.MediumBlue;
            this.ColorChoosing.Location = new System.Drawing.Point(672, 38);
            this.ColorChoosing.Name = "ColorChoosing";
            this.ColorChoosing.Size = new System.Drawing.Size(169, 38);
            this.ColorChoosing.TabIndex = 9;
            this.ColorChoosing.Text = "ChooseYourColor";
            this.ColorChoosing.UseVisualStyleBackColor = true;
            this.ColorChoosing.Click += new System.EventHandler(this.ColorChoosing_Click);
            // 
            // ConnectToserverButton
            // 
            this.ConnectToserverButton.BackColor = System.Drawing.Color.LightGray;
            this.ConnectToserverButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectToserverButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.ConnectToserverButton.Location = new System.Drawing.Point(205, 408);
            this.ConnectToserverButton.Name = "ConnectToserverButton";
            this.ConnectToserverButton.Size = new System.Drawing.Size(133, 39);
            this.ConnectToserverButton.TabIndex = 11;
            this.ConnectToserverButton.Text = "Connect";
            this.ConnectToserverButton.UseVisualStyleBackColor = false;
            this.ConnectToserverButton.Click += new System.EventHandler(this.ConnectToserverButton_Click);
            // 
            // DisconnectFromServerButton
            // 
            this.DisconnectFromServerButton.BackColor = System.Drawing.Color.LightGray;
            this.DisconnectFromServerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DisconnectFromServerButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectFromServerButton.ForeColor = System.Drawing.Color.Tomato;
            this.DisconnectFromServerButton.Location = new System.Drawing.Point(444, 408);
            this.DisconnectFromServerButton.Name = "DisconnectFromServerButton";
            this.DisconnectFromServerButton.Size = new System.Drawing.Size(158, 39);
            this.DisconnectFromServerButton.TabIndex = 12;
            this.DisconnectFromServerButton.Text = "Disconnect";
            this.DisconnectFromServerButton.UseVisualStyleBackColor = false;
            this.DisconnectFromServerButton.Click += new System.EventHandler(this.DisconnectFromServerButton_Click);
            // 
            // RedLightPanel
            // 
            this.RedLightPanel.Controls.Add(this.label1);
            this.RedLightPanel.Controls.Add(this.RedLamp);
            this.RedLightPanel.Location = new System.Drawing.Point(12, 109);
            this.RedLightPanel.Name = "RedLightPanel";
            this.RedLightPanel.Size = new System.Drawing.Size(187, 82);
            this.RedLightPanel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "You are Offline";
            // 
            // GreenLightPanel
            // 
            this.GreenLightPanel.Controls.Add(this.label2);
            this.GreenLightPanel.Controls.Add(this.GreenLamp);
            this.GreenLightPanel.Location = new System.Drawing.Point(12, 214);
            this.GreenLightPanel.Name = "GreenLightPanel";
            this.GreenLightPanel.Size = new System.Drawing.Size(172, 82);
            this.GreenLightPanel.TabIndex = 16;
            this.GreenLightPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "You Are Online";
            // 
            // NoServersOnlineLabel
            // 
            this.NoServersOnlineLabel.AutoSize = true;
            this.NoServersOnlineLabel.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoServersOnlineLabel.ForeColor = System.Drawing.Color.Tomato;
            this.NoServersOnlineLabel.Location = new System.Drawing.Point(44, 465);
            this.NoServersOnlineLabel.Name = "NoServersOnlineLabel";
            this.NoServersOnlineLabel.Size = new System.Drawing.Size(0, 23);
            this.NoServersOnlineLabel.TabIndex = 17;
            // 
            // PrivateMessageButton
            // 
            this.PrivateMessageButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivateMessageButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.PrivateMessageButton.Location = new System.Drawing.Point(783, 318);
            this.PrivateMessageButton.Name = "PrivateMessageButton";
            this.PrivateMessageButton.Size = new System.Drawing.Size(151, 39);
            this.PrivateMessageButton.TabIndex = 18;
            this.PrivateMessageButton.Text = "PrivateMessage";
            this.PrivateMessageButton.UseVisualStyleBackColor = true;
            this.PrivateMessageButton.Click += new System.EventHandler(this.PrivateMessageButton_Click);
            // 
            // Userlabel
            // 
            this.Userlabel.AutoSize = true;
            this.Userlabel.Font = new System.Drawing.Font("Palatino Linotype", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Userlabel.ForeColor = System.Drawing.Color.Indigo;
            this.Userlabel.Location = new System.Drawing.Point(12, 13);
            this.Userlabel.Name = "Userlabel";
            this.Userlabel.Size = new System.Drawing.Size(0, 44);
            this.Userlabel.TabIndex = 19;
            // 
            // AllUsersCombobox
            // 
            this.AllUsersCombobox.AccessibleName = "";
            this.AllUsersCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllUsersCombobox.FormattingEnabled = true;
            this.AllUsersCombobox.Location = new System.Drawing.Point(783, 408);
            this.AllUsersCombobox.Name = "AllUsersCombobox";
            this.AllUsersCombobox.Size = new System.Drawing.Size(151, 24);
            this.AllUsersCombobox.TabIndex = 21;
            this.AllUsersCombobox.Tag = "";
            this.AllUsersCombobox.Text = "Choose Users:";
            this.AllUsersCombobox.SelectionChangeCommitted += new System.EventHandler(this.AllUsersCombobox_SelectionChangeCommitted);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(504, 652);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(98, 13);
            this.linkLabel1.TabIndex = 28;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Folow us on Github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(487, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 29);
            this.label4.TabIndex = 27;
            this.label4.Text = "Powered by";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ClientInterface.Properties.Resources.GitHub_Mark_32px;
            this.pictureBox2.Location = new System.Drawing.Point(530, 668);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 37);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ClientInterface.Properties.Resources._4_Grayscale_logo_on_transparent_238x75;
            this.pictureBox1.Location = new System.Drawing.Point(431, 556);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 72);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // GreenLamp
            // 
            this.GreenLamp.Image = global::ClientInterface.Properties.Resources.green;
            this.GreenLamp.Location = new System.Drawing.Point(77, 0);
            this.GreenLamp.Name = "GreenLamp";
            this.GreenLamp.Size = new System.Drawing.Size(35, 35);
            this.GreenLamp.TabIndex = 14;
            this.GreenLamp.TabStop = false;
            // 
            // RedLamp
            // 
            this.RedLamp.Image = global::ClientInterface.Properties.Resources.red;
            this.RedLamp.Location = new System.Drawing.Point(77, 3);
            this.RedLamp.Name = "RedLamp";
            this.RedLamp.Size = new System.Drawing.Size(35, 34);
            this.RedLamp.TabIndex = 13;
            this.RedLamp.TabStop = false;
            // 
            // UserInterfaceClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(999, 726);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AllUsersCombobox);
            this.Controls.Add(this.Userlabel);
            this.Controls.Add(this.PrivateMessageButton);
            this.Controls.Add(this.NoServersOnlineLabel);
            this.Controls.Add(this.GreenLightPanel);
            this.Controls.Add(this.RedLightPanel);
            this.Controls.Add(this.DisconnectFromServerButton);
            this.Controls.Add(this.ConnectToserverButton);
            this.Controls.Add(this.changeFontButton);
            this.Controls.Add(this.ColorChoosing);
            this.Controls.Add(this.sendmessageButton);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Name = "UserInterfaceClass";
            this.Text = "ClientInterface";
            this.Load += new System.EventHandler(this.UserInterfaceClass_Load);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.RedLightPanel.ResumeLayout(false);
            this.RedLightPanel.PerformLayout();
            this.GreenLightPanel.ResumeLayout(false);
            this.GreenLightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.TextBox TextMessages;
        public System.Windows.Forms.Button sendmessageButton;
        private System.Windows.Forms.Button changeFontButton;
        public System.Windows.Forms.Button ColorChoosing;
        private System.Windows.Forms.Button ConnectToserverButton;
        private System.Windows.Forms.Button DisconnectFromServerButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PictureBox RedLamp;
        private System.Windows.Forms.PictureBox GreenLamp;
        private System.Windows.Forms.Panel RedLightPanel;
        private System.Windows.Forms.Panel GreenLightPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NoServersOnlineLabel;
       internal System.Windows.Forms.ListBox ChatListBox;
        private System.Windows.Forms.Button PrivateMessageButton;
        private System.Windows.Forms.Label Userlabel;
        private System.Windows.Forms.ComboBox AllUsersCombobox;
        private System.Windows.Forms.Label SendtoLabel;
        private System.Windows.Forms.Label User1Label;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

