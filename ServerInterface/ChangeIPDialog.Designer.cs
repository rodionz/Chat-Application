namespace ServerInterface
{
    partial class ChangeIPDialog
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
            this.ConfirmIP = new System.Windows.Forms.Button();
            this.clearIP = new System.Windows.Forms.Button();
            this.IPmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ipConfirmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConfirmIP
            // 
            this.ConfirmIP.Font = new System.Drawing.Font("Narkisim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ConfirmIP.Location = new System.Drawing.Point(516, 12);
            this.ConfirmIP.Name = "ConfirmIP";
            this.ConfirmIP.Size = new System.Drawing.Size(86, 26);
            this.ConfirmIP.TabIndex = 28;
            this.ConfirmIP.Text = "ConfirmIP";
            this.ConfirmIP.UseVisualStyleBackColor = true;
            this.ConfirmIP.Click += new System.EventHandler(this.ConfirmIP_Click);
            // 
            // clearIP
            // 
            this.clearIP.BackColor = System.Drawing.Color.Red;
            this.clearIP.Location = new System.Drawing.Point(408, 15);
            this.clearIP.Name = "clearIP";
            this.clearIP.Size = new System.Drawing.Size(66, 23);
            this.clearIP.TabIndex = 27;
            this.clearIP.Text = "Clear";
            this.clearIP.UseVisualStyleBackColor = false;
            this.clearIP.Click += new System.EventHandler(this.clearIP_Click);
            // 
            // IPmaskedTextBox
            // 
            this.IPmaskedTextBox.Location = new System.Drawing.Point(237, 18);
            this.IPmaskedTextBox.Mask = " ###.###.###.###";
            this.IPmaskedTextBox.Name = "IPmaskedTextBox";
            this.IPmaskedTextBox.Size = new System.Drawing.Size(108, 20);
            this.IPmaskedTextBox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "Enter IP Adress:";
            // 
            // ipConfirmLabel
            // 
            this.ipConfirmLabel.AutoSize = true;
            this.ipConfirmLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipConfirmLabel.Location = new System.Drawing.Point(307, 65);
            this.ipConfirmLabel.Name = "ipConfirmLabel";
            this.ipConfirmLabel.Size = new System.Drawing.Size(0, 19);
            this.ipConfirmLabel.TabIndex = 29;
            // 
            // ChangeIPDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(614, 104);
            this.Controls.Add(this.ipConfirmLabel);
            this.Controls.Add(this.ConfirmIP);
            this.Controls.Add(this.clearIP);
            this.Controls.Add(this.IPmaskedTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ChangeIPDialog";
            this.Text = "ChangeIPDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button ConfirmIP;
        private System.Windows.Forms.Button clearIP;
        public System.Windows.Forms.MaskedTextBox IPmaskedTextBox;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ipConfirmLabel;
    }
}