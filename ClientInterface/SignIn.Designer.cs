namespace ClientInterface
{
    partial class SignIn
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IPmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.MaskedTextBox();
            this.clearIP = new System.Windows.Forms.Button();
            this.UsernameClearButton = new System.Windows.Forms.Button();
            this.Clearportbutton = new System.Windows.Forms.Button();
            this.ConfirmIPandPortButton = new System.Windows.Forms.Button();
            this.NicknameConfirmationButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.NickNameConfirmationLabel = new System.Windows.Forms.Label();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Enter you port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Enter Your UserName:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "Enter IP Adress:";
            // 
            // IPmaskedTextBox
            // 
            this.IPmaskedTextBox.Location = new System.Drawing.Point(296, 22);
            this.IPmaskedTextBox.Mask = " ###.###.###.###";
            this.IPmaskedTextBox.Name = "IPmaskedTextBox";
            this.IPmaskedTextBox.Size = new System.Drawing.Size(160, 20);
            this.IPmaskedTextBox.TabIndex = 17;
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(260, 209);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(143, 20);
            this.UserNameBox.TabIndex = 18;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(296, 68);
            this.portTextBox.Mask = "00000";
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(160, 20);
            this.portTextBox.TabIndex = 19;
            this.portTextBox.ValidatingType = typeof(int);
            // 
            // clearIP
            // 
            this.clearIP.BackColor = System.Drawing.Color.Red;
            this.clearIP.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearIP.Location = new System.Drawing.Point(502, 22);
            this.clearIP.Name = "clearIP";
            this.clearIP.Size = new System.Drawing.Size(75, 29);
            this.clearIP.TabIndex = 20;
            this.clearIP.Text = "Clear";
            this.clearIP.UseVisualStyleBackColor = false;
            this.clearIP.Click += new System.EventHandler(this.clearIP_Click);
            // 
            // UsernameClearButton
            // 
            this.UsernameClearButton.BackColor = System.Drawing.Color.Red;
            this.UsernameClearButton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameClearButton.Location = new System.Drawing.Point(448, 209);
            this.UsernameClearButton.Name = "UsernameClearButton";
            this.UsernameClearButton.Size = new System.Drawing.Size(79, 27);
            this.UsernameClearButton.TabIndex = 21;
            this.UsernameClearButton.Text = "Clear";
            this.UsernameClearButton.UseVisualStyleBackColor = false;
            this.UsernameClearButton.Click += new System.EventHandler(this.UsernameClearButton_Click);
            // 
            // Clearportbutton
            // 
            this.Clearportbutton.BackColor = System.Drawing.Color.Red;
            this.Clearportbutton.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clearportbutton.Location = new System.Drawing.Point(502, 68);
            this.Clearportbutton.Name = "Clearportbutton";
            this.Clearportbutton.Size = new System.Drawing.Size(75, 29);
            this.Clearportbutton.TabIndex = 22;
            this.Clearportbutton.Text = "Clear";
            this.Clearportbutton.UseVisualStyleBackColor = false;
            this.Clearportbutton.Click += new System.EventHandler(this.Clearportbutton_Click);
            // 
            // ConfirmIPandPortButton
            // 
            this.ConfirmIPandPortButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmIPandPortButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.ConfirmIPandPortButton.Location = new System.Drawing.Point(296, 136);
            this.ConfirmIPandPortButton.Name = "ConfirmIPandPortButton";
            this.ConfirmIPandPortButton.Size = new System.Drawing.Size(160, 34);
            this.ConfirmIPandPortButton.TabIndex = 23;
            this.ConfirmIPandPortButton.Text = "Confirm IP and Port";
            this.ConfirmIPandPortButton.UseVisualStyleBackColor = true;
            this.ConfirmIPandPortButton.Click += new System.EventHandler(this.ConfirmIP_Click);
            // 
            // NicknameConfirmationButton
            // 
            this.NicknameConfirmationButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NicknameConfirmationButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NicknameConfirmationButton.Location = new System.Drawing.Point(586, 202);
            this.NicknameConfirmationButton.Name = "NicknameConfirmationButton";
            this.NicknameConfirmationButton.Size = new System.Drawing.Size(86, 34);
            this.NicknameConfirmationButton.TabIndex = 24;
            this.NicknameConfirmationButton.Text = "Confirm UserName";
            this.NicknameConfirmationButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NicknameConfirmationButton.UseVisualStyleBackColor = true;
            this.NicknameConfirmationButton.Click += new System.EventHandler(this.NicknameConfirmationButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.ConnectButton.Location = new System.Drawing.Point(296, 306);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(118, 36);
            this.ConnectButton.TabIndex = 26;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // NickNameConfirmationLabel
            // 
            this.NickNameConfirmationLabel.AutoSize = true;
            this.NickNameConfirmationLabel.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NickNameConfirmationLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NickNameConfirmationLabel.Location = new System.Drawing.Point(241, 253);
            this.NickNameConfirmationLabel.Name = "NickNameConfirmationLabel";
            this.NickNameConfirmationLabel.Size = new System.Drawing.Size(0, 19);
            this.NickNameConfirmationLabel.TabIndex = 28;
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLabel.Location = new System.Drawing.Point(241, 166);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(0, 19);
            this.WarningLabel.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(121, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(551, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Please pay attention that  an attempt to connect to enexisting server will cause " +
    "a delay (about 10 sec)";
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(728, 355);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.NickNameConfirmationLabel);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.NicknameConfirmationButton);
            this.Controls.Add(this.ConfirmIPandPortButton);
            this.Controls.Add(this.Clearportbutton);
            this.Controls.Add(this.UsernameClearButton);
            this.Controls.Add(this.clearIP);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.IPmaskedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SignIn";
            this.Text = "SignIn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignIn_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.MaskedTextBox IPmaskedTextBox;
        public System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.MaskedTextBox portTextBox;
        private System.Windows.Forms.Button clearIP;
        private System.Windows.Forms.Button UsernameClearButton;
        private System.Windows.Forms.Button Clearportbutton;
        public System.Windows.Forms.Button ConfirmIPandPortButton;
        public System.Windows.Forms.Button NicknameConfirmationButton;
        public System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label NickNameConfirmationLabel;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.Label label4;
    }
}