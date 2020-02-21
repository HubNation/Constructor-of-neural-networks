namespace Project
{
    partial class Authorization
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
            this.buttonSI = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.buttonSU = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSI
            // 
            this.buttonSI.Location = new System.Drawing.Point(28, 76);
            this.buttonSI.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSI.Name = "buttonSI";
            this.buttonSI.Size = new System.Drawing.Size(74, 23);
            this.buttonSI.TabIndex = 0;
            this.buttonSI.Text = "Sign In";
            this.buttonSI.UseVisualStyleBackColor = true;
            this.buttonSI.Click += new System.EventHandler(this.buttonSI_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(12, 17);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(36, 13);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "Login:";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(54, 14);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(153, 20);
            this.textBoxLog.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 47);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(71, 44);
            this.textBoxPass.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(136, 20);
            this.textBoxPass.TabIndex = 4;
            this.textBoxPass.UseSystemPasswordChar = true;
            // 
            // buttonSU
            // 
            this.buttonSU.Location = new System.Drawing.Point(121, 76);
            this.buttonSU.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSU.Name = "buttonSU";
            this.buttonSU.Size = new System.Drawing.Size(74, 23);
            this.buttonSU.TabIndex = 5;
            this.buttonSU.Text = "Sign Up";
            this.buttonSU.UseVisualStyleBackColor = true;
            this.buttonSU.Click += new System.EventHandler(this.buttonSU_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 113);
            this.Controls.Add(this.buttonSU);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.buttonSI);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSI;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button buttonSU;
    }
}