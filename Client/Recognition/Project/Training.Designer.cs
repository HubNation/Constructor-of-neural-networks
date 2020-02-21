namespace Project
{
    partial class Training
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
            this.label = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.labelRespond = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonTeach = new System.Windows.Forms.Button();
            this.comboFlags = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 219);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(108, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Reply of the network:";
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(15, 276);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 4;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // labelRespond
            // 
            this.labelRespond.AutoSize = true;
            this.labelRespond.Location = new System.Drawing.Point(141, 219);
            this.labelRespond.Name = "labelRespond";
            this.labelRespond.Size = new System.Drawing.Size(34, 13);
            this.labelRespond.TabIndex = 5;
            this.labelRespond.Text = "Blank";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(120, 278);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(68, 307);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonTeach
            // 
            this.buttonTeach.Location = new System.Drawing.Point(15, 247);
            this.buttonTeach.Name = "buttonTeach";
            this.buttonTeach.Size = new System.Drawing.Size(75, 23);
            this.buttonTeach.TabIndex = 8;
            this.buttonTeach.Text = "Teach";
            this.buttonTeach.UseVisualStyleBackColor = true;
            this.buttonTeach.Click += new System.EventHandler(this.buttonTeach_Click);
            // 
            // comboFlags
            // 
            this.comboFlags.FormattingEnabled = true;
            this.comboFlags.Location = new System.Drawing.Point(115, 249);
            this.comboFlags.Name = "comboFlags";
            this.comboFlags.Size = new System.Drawing.Size(87, 21);
            this.comboFlags.TabIndex = 9;
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 338);
            this.Controls.Add(this.comboFlags);
            this.Controls.Add(this.buttonTeach);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelRespond);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Training";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelRespond;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonTeach;
        private System.Windows.Forms.ComboBox comboFlags;
    }
}