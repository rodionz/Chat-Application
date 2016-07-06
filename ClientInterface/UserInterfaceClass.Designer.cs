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
            this.ChatrichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
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
            this.RedLamp = new System.Windows.Forms.PictureBox();
            this.GreenLightPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.GreenLamp = new System.Windows.Forms.PictureBox();
            this.PrivateMessageButton = new System.Windows.Forms.Button();
            this.Userlabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PrivatecheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.UserPanel = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.RedLightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).BeginInit();
            this.GreenLightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.UserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel5.Controls.Add(this.ChatrichTextBox);
            this.panel5.Location = new System.Drawing.Point(147, 99);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(336, 228);
            this.panel5.TabIndex = 3;
            // 
            // ChatrichTextBox
            // 
            this.ChatrichTextBox.Location = new System.Drawing.Point(27, 16);
            this.ChatrichTextBox.Name = "ChatrichTextBox";
            this.ChatrichTextBox.Size = new System.Drawing.Size(286, 192);
            this.ChatrichTextBox.TabIndex = 31;
            this.ChatrichTextBox.Text = "";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel6.Controls.Add(this.TextMessages);
            this.panel6.Location = new System.Drawing.Point(147, 333);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(336, 70);
            this.panel6.TabIndex = 4;
            // 
            // TextMessages
            // 
            this.TextMessages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TextMessages.Location = new System.Drawing.Point(12, 16);
            this.TextMessages.Multiline = true;
            this.TextMessages.Name = "TextMessages";
            this.TextMessages.Size = new System.Drawing.Size(306, 39);
            this.TextMessages.TabIndex = 0;
            this.TextMessages.FontChanged += new System.EventHandler(this.TextMessages_FontChanged);
            this.TextMessages.ForeColorChanged += new System.EventHandler(this.TextMessages_ForeColorChanged);
            // 
            // sendmessageButton
            // 
            this.sendmessageButton.Enabled = false;
            this.sendmessageButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendmessageButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.sendmessageButton.Location = new System.Drawing.Point(147, 420);
            this.sendmessageButton.Name = "sendmessageButton";
            this.sendmessageButton.Size = new System.Drawing.Size(108, 39);
            this.sendmessageButton.TabIndex = 8;
            this.sendmessageButton.Text = "SEND";
            this.sendmessageButton.UseVisualStyleBackColor = true;
            this.sendmessageButton.Click += new System.EventHandler(this.sendmessageButton_Click);
            // 
            // changeFontButton
            // 
            this.changeFontButton.Enabled = false;
            this.changeFontButton.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeFontButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.changeFontButton.Location = new System.Drawing.Point(11, 293);
            this.changeFontButton.Name = "changeFontButton";
            this.changeFontButton.Size = new System.Drawing.Size(118, 36);
            this.changeFontButton.TabIndex = 10;
            this.changeFontButton.Text = "Change Font";
            this.changeFontButton.UseVisualStyleBackColor = true;
            this.changeFontButton.Click += new System.EventHandler(this.changeFontButton_Click);
            // 
            // ColorChoosing
            // 
            this.ColorChoosing.Enabled = false;
            this.ColorChoosing.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorChoosing.ForeColor = System.Drawing.Color.MediumBlue;
            this.ColorChoosing.Location = new System.Drawing.Point(11, 233);
            this.ColorChoosing.Name = "ColorChoosing";
            this.ColorChoosing.Size = new System.Drawing.Size(118, 38);
            this.ColorChoosing.TabIndex = 9;
            this.ColorChoosing.Text = "Change Color";
            this.ColorChoosing.UseVisualStyleBackColor = true;
            this.ColorChoosing.Click += new System.EventHandler(this.ColorChoosing_Click);
            // 
            // ConnectToserverButton
            // 
            this.ConnectToserverButton.BackColor = System.Drawing.Color.LightGray;
            this.ConnectToserverButton.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectToserverButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.ConnectToserverButton.Location = new System.Drawing.Point(11, 105);
            this.ConnectToserverButton.Name = "ConnectToserverButton";
            this.ConnectToserverButton.Size = new System.Drawing.Size(118, 39);
            this.ConnectToserverButton.TabIndex = 11;
            this.ConnectToserverButton.Text = "Connect";
            this.ConnectToserverButton.UseVisualStyleBackColor = true;
            this.ConnectToserverButton.Click += new System.EventHandler(this.ConnectToserverButton_Click);
            // 
            // DisconnectFromServerButton
            // 
            this.DisconnectFromServerButton.BackColor = System.Drawing.Color.LightGray;
            this.DisconnectFromServerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DisconnectFromServerButton.Enabled = false;
            this.DisconnectFromServerButton.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectFromServerButton.ForeColor = System.Drawing.Color.Tomato;
            this.DisconnectFromServerButton.Location = new System.Drawing.Point(11, 167);
            this.DisconnectFromServerButton.Name = "DisconnectFromServerButton";
            this.DisconnectFromServerButton.Size = new System.Drawing.Size(116, 39);
            this.DisconnectFromServerButton.TabIndex = 12;
            this.DisconnectFromServerButton.Text = "Disconnect";
            this.DisconnectFromServerButton.UseVisualStyleBackColor = true;
            this.DisconnectFromServerButton.Click += new System.EventHandler(this.DisconnectFromServerButton_Click);
            // 
            // RedLightPanel
            // 
            this.RedLightPanel.Controls.Add(this.label1);
            this.RedLightPanel.Controls.Add(this.RedLamp);
            this.RedLightPanel.Location = new System.Drawing.Point(316, 11);
            this.RedLightPanel.Name = "RedLightPanel";
            this.RedLightPanel.Size = new System.Drawing.Size(144, 82);
            this.RedLightPanel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "You are Offline";
            // 
            // RedLamp
            // 
            this.RedLamp.Image = global::ClientInterface.Properties.Resources.red;
            this.RedLamp.Location = new System.Drawing.Point(60, 3);
            this.RedLamp.Name = "RedLamp";
            this.RedLamp.Size = new System.Drawing.Size(35, 34);
            this.RedLamp.TabIndex = 13;
            this.RedLamp.TabStop = false;
            // 
            // GreenLightPanel
            // 
            this.GreenLightPanel.Controls.Add(this.label2);
            this.GreenLightPanel.Controls.Add(this.GreenLamp);
            this.GreenLightPanel.Location = new System.Drawing.Point(165, 11);
            this.GreenLightPanel.Name = "GreenLightPanel";
            this.GreenLightPanel.Size = new System.Drawing.Size(141, 82);
            this.GreenLightPanel.TabIndex = 16;
            this.GreenLightPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(3, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "You Are Online";
            // 
            // GreenLamp
            // 
            this.GreenLamp.Image = global::ClientInterface.Properties.Resources.green;
            this.GreenLamp.Location = new System.Drawing.Point(59, 0);
            this.GreenLamp.Name = "GreenLamp";
            this.GreenLamp.Size = new System.Drawing.Size(35, 35);
            this.GreenLamp.TabIndex = 14;
            this.GreenLamp.TabStop = false;
            // 
            // PrivateMessageButton
            // 
            this.PrivateMessageButton.Enabled = false;
            this.PrivateMessageButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivateMessageButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.PrivateMessageButton.Location = new System.Drawing.Point(355, 418);
            this.PrivateMessageButton.Name = "PrivateMessageButton";
            this.PrivateMessageButton.Size = new System.Drawing.Size(128, 41);
            this.PrivateMessageButton.TabIndex = 18;
            this.PrivateMessageButton.Text = "Private Message";
            this.PrivateMessageButton.UseVisualStyleBackColor = true;
            this.PrivateMessageButton.Click += new System.EventHandler(this.PrivateMessageButton_Click);
            // 
            // Userlabel
            // 
            this.Userlabel.AutoSize = true;
            this.Userlabel.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Userlabel.ForeColor = System.Drawing.Color.Indigo;
            this.Userlabel.Location = new System.Drawing.Point(3, 7);
            this.Userlabel.Name = "Userlabel";
            this.Userlabel.Size = new System.Drawing.Size(62, 32);
            this.Userlabel.TabIndex = 19;
            this.Userlabel.Text = "user";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ClientInterface.Properties.Resources._4_Grayscale_logo_on_transparent_238x75;
            this.pictureBox1.Location = new System.Drawing.Point(11, 503);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 72);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // PrivatecheckedListBox
            // 
            this.PrivatecheckedListBox.FormattingEnabled = true;
            this.PrivatecheckedListBox.Location = new System.Drawing.Point(350, 481);
            this.PrivatecheckedListBox.Name = "PrivatecheckedListBox";
            this.PrivatecheckedListBox.Size = new System.Drawing.Size(151, 94);
            this.PrivatecheckedListBox.TabIndex = 30;
            this.PrivatecheckedListBox.Visible = false;
            this.PrivatecheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PrivatecheckedListBox_ItemCheck);
            // 
            // UserPanel
            // 
            this.UserPanel.Controls.Add(this.pictureBox1);
            this.UserPanel.Controls.Add(this.Userlabel);
            this.UserPanel.Controls.Add(this.PrivatecheckedListBox);
            this.UserPanel.Controls.Add(this.GreenLightPanel);
            this.UserPanel.Controls.Add(this.RedLightPanel);
            this.UserPanel.Controls.Add(this.panel5);
            this.UserPanel.Controls.Add(this.ColorChoosing);
            this.UserPanel.Controls.Add(this.changeFontButton);
            this.UserPanel.Controls.Add(this.PrivateMessageButton);
            this.UserPanel.Controls.Add(this.ConnectToserverButton);
            this.UserPanel.Controls.Add(this.DisconnectFromServerButton);
            this.UserPanel.Controls.Add(this.panel6);
            this.UserPanel.Controls.Add(this.sendmessageButton);
            this.UserPanel.Location = new System.Drawing.Point(1, 4);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(530, 635);
            this.UserPanel.TabIndex = 31;
            // 
            // UserInterfaceClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(531, 591);
            this.Controls.Add(this.UserPanel);
            this.Name = "UserInterfaceClass";
            this.Text = "ClientInterface";
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.RedLightPanel.ResumeLayout(false);
            this.RedLightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedLamp)).EndInit();
            this.GreenLightPanel.ResumeLayout(false);
            this.GreenLightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button PrivateMessageButton;
        private System.Windows.Forms.Label Userlabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckedListBox PrivatecheckedListBox;
        private System.Windows.Forms.RichTextBox ChatrichTextBox;
        private System.Windows.Forms.Panel UserPanel;
    }
}

