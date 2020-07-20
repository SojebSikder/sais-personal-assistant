namespace Voice_Recognition
{
    partial class email
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
            this.btn_Send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textSub = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textMes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textSmtp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxSSl = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(264, 43);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 0;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxSSl);
            this.groupBox1.Controls.Add(this.textUsername);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textSmtp);
            this.groupBox1.Controls.Add(this.textPort);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.btn_Send);
            this.groupBox1.Location = new System.Drawing.Point(45, 216);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textTo
            // 
            this.textTo.Location = new System.Drawing.Point(93, 19);
            this.textTo.Name = "textTo";
            this.textTo.Size = new System.Drawing.Size(356, 20);
            this.textTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CC";
            // 
            // textCC
            // 
            this.textCC.Location = new System.Drawing.Point(93, 46);
            this.textCC.Name = "textCC";
            this.textCC.Size = new System.Drawing.Size(356, 20);
            this.textCC.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sub";
            // 
            // textSub
            // 
            this.textSub.Location = new System.Drawing.Point(93, 72);
            this.textSub.Name = "textSub";
            this.textSub.Size = new System.Drawing.Size(356, 20);
            this.textSub.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Message";
            // 
            // textMes
            // 
            this.textMes.Location = new System.Drawing.Point(93, 98);
            this.textMes.Multiline = true;
            this.textMes.Name = "textMes";
            this.textMes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textMes.Size = new System.Drawing.Size(356, 87);
            this.textMes.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "UserName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Password";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(67, 23);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(191, 20);
            this.textUsername.TabIndex = 3;
            this.textUsername.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(67, 50);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(191, 20);
            this.textPassword.TabIndex = 3;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(67, 76);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(65, 20);
            this.textPort.TabIndex = 3;
            this.textPort.Text = "587";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Port";
            // 
            // textSmtp
            // 
            this.textSmtp.Location = new System.Drawing.Point(181, 76);
            this.textSmtp.Name = "textSmtp";
            this.textSmtp.Size = new System.Drawing.Size(85, 20);
            this.textSmtp.TabIndex = 3;
            this.textSmtp.Text = "smtp.gmail.com";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "SMTP";
            // 
            // checkBoxSSl
            // 
            this.checkBoxSSl.AutoSize = true;
            this.checkBoxSSl.Location = new System.Drawing.Point(264, 25);
            this.checkBoxSSl.Name = "checkBoxSSl";
            this.checkBoxSSl.Size = new System.Drawing.Size(46, 17);
            this.checkBoxSSl.TabIndex = 4;
            this.checkBoxSSl.Text = "SSL";
            this.checkBoxSSl.UseVisualStyleBackColor = true;
            // 
            // email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 407);
            this.Controls.Add(this.textMes);
            this.Controls.Add(this.textSub);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textCC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "email";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Send Mail";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.email_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textSub;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textMes;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textSmtp;
        private System.Windows.Forms.CheckBox checkBoxSSl;
    }
}