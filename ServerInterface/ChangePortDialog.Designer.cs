namespace ServerInterface
{
    partial class ChangePortDialog
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
            this.PortConfirmationButtom = new System.Windows.Forms.Button();
            this.Clearportbutton = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portConfirmLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PortConfirmationButtom
            // 
            this.PortConfirmationButtom.Font = new System.Drawing.Font("Narkisim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PortConfirmationButtom.Location = new System.Drawing.Point(526, 36);
            this.PortConfirmationButtom.Name = "PortConfirmationButtom";
            this.PortConfirmationButtom.Size = new System.Drawing.Size(97, 23);
            this.PortConfirmationButtom.TabIndex = 30;
            this.PortConfirmationButtom.Text = "Confirm port";
            this.PortConfirmationButtom.UseVisualStyleBackColor = true;
            this.PortConfirmationButtom.Click += new System.EventHandler(this.PortConfirmationButtom_Click);
            // 
            // Clearportbutton
            // 
            this.Clearportbutton.BackColor = System.Drawing.Color.Red;
            this.Clearportbutton.Location = new System.Drawing.Point(421, 36);
            this.Clearportbutton.Name = "Clearportbutton";
            this.Clearportbutton.Size = new System.Drawing.Size(66, 23);
            this.Clearportbutton.TabIndex = 29;
            this.Clearportbutton.Text = "Clear";
            this.Clearportbutton.UseVisualStyleBackColor = false;
            this.Clearportbutton.Click += new System.EventHandler(this.Clearportbutton_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(264, 39);
            this.portTextBox.Mask = "00000";
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(108, 20);
            this.portTextBox.TabIndex = 28;
            this.portTextBox.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 26);
            this.label3.TabIndex = 27;
            this.label3.Text = "Enter you port:";
            // 
            // portConfirmLabel
            // 
            this.portConfirmLabel.AutoSize = true;
            this.portConfirmLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portConfirmLabel.Location = new System.Drawing.Point(318, 85);
            this.portConfirmLabel.Name = "portConfirmLabel";
            this.portConfirmLabel.Size = new System.Drawing.Size(0, 19);
            this.portConfirmLabel.TabIndex = 31;
            // 
            // ChangePortDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(687, 134);
            this.Controls.Add(this.portConfirmLabel);
            this.Controls.Add(this.PortConfirmationButtom);
            this.Controls.Add(this.Clearportbutton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label3);
            this.Name = "ChangePortDialog";
            this.Text = "ChangePortDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PortConfirmationButtom;
        private System.Windows.Forms.Button Clearportbutton;
        private System.Windows.Forms.MaskedTextBox portTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label portConfirmLabel;
    }
}