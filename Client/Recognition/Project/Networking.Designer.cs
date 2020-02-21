namespace Project
{
    partial class Networking
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelIN = new System.Windows.Forms.Label();
            this.labelHN = new System.Windows.Forms.Label();
            this.labelON = new System.Windows.Forms.Label();
            this.labelSL = new System.Windows.Forms.Label();
            this.numericIN = new System.Windows.Forms.NumericUpDown();
            this.numericHN = new System.Windows.Forms.NumericUpDown();
            this.numericON = new System.Windows.Forms.NumericUpDown();
            this.numericSL = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelLB = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(169, 150);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(53, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // labelIN
            // 
            this.labelIN.AutoSize = true;
            this.labelIN.Location = new System.Drawing.Point(13, 45);
            this.labelIN.Name = "labelIN";
            this.labelIN.Size = new System.Drawing.Size(34, 13);
            this.labelIN.TabIndex = 7;
            this.labelIN.Text = "Input:";
            // 
            // labelHN
            // 
            this.labelHN.AutoSize = true;
            this.labelHN.Location = new System.Drawing.Point(6, 80);
            this.labelHN.Name = "labelHN";
            this.labelHN.Size = new System.Drawing.Size(44, 13);
            this.labelHN.TabIndex = 8;
            this.labelHN.Text = "Hidden:";
            // 
            // labelON
            // 
            this.labelON.AutoSize = true;
            this.labelON.Location = new System.Drawing.Point(8, 115);
            this.labelON.Name = "labelON";
            this.labelON.Size = new System.Drawing.Size(42, 13);
            this.labelON.TabIndex = 9;
            this.labelON.Text = "Output:";
            // 
            // labelSL
            // 
            this.labelSL.AutoSize = true;
            this.labelSL.Location = new System.Drawing.Point(6, 154);
            this.labelSL.Name = "labelSL";
            this.labelSL.Size = new System.Drawing.Size(41, 13);
            this.labelSL.TabIndex = 10;
            this.labelSL.Text = "Speed:";
            // 
            // numericIN
            // 
            this.numericIN.Location = new System.Drawing.Point(54, 45);
            this.numericIN.Maximum = new decimal(new int[] {
            784,
            0,
            0,
            0});
            this.numericIN.Minimum = new decimal(new int[] {
            784,
            0,
            0,
            0});
            this.numericIN.Name = "numericIN";
            this.numericIN.Size = new System.Drawing.Size(99, 20);
            this.numericIN.TabIndex = 11;
            this.numericIN.Value = new decimal(new int[] {
            784,
            0,
            0,
            0});
            // 
            // numericHN
            // 
            this.numericHN.Location = new System.Drawing.Point(53, 80);
            this.numericHN.Name = "numericHN";
            this.numericHN.Size = new System.Drawing.Size(99, 20);
            this.numericHN.TabIndex = 12;
            // 
            // numericON
            // 
            this.numericON.Location = new System.Drawing.Point(53, 115);
            this.numericON.Name = "numericON";
            this.numericON.Size = new System.Drawing.Size(99, 20);
            this.numericON.TabIndex = 13;
            // 
            // numericSL
            // 
            this.numericSL.DecimalPlaces = 3;
            this.numericSL.Location = new System.Drawing.Point(53, 152);
            this.numericSL.Name = "numericSL";
            this.numericSL.Size = new System.Drawing.Size(99, 20);
            this.numericSL.TabIndex = 14;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(250, 150);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 15;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelLB
            // 
            this.labelLB.AutoSize = true;
            this.labelLB.Location = new System.Drawing.Point(168, 12);
            this.labelLB.Name = "labelLB";
            this.labelLB.Size = new System.Drawing.Size(114, 13);
            this.labelLB.TabIndex = 16;
            this.labelLB.Text = "Flags of output values:";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName});
            this.dataGridView.Location = new System.Drawing.Point(169, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(156, 116);
            this.dataGridView.TabIndex = 17;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 153;
            // 
            // Networking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 184);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelLB);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericSL);
            this.Controls.Add(this.numericON);
            this.Controls.Add(this.numericHN);
            this.Controls.Add(this.numericIN);
            this.Controls.Add(this.labelSL);
            this.Controls.Add(this.labelON);
            this.Controls.Add(this.labelHN);
            this.Controls.Add(this.labelIN);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonCancel);
            this.Name = "Networking";
            this.Text = "Networking";
            ((System.ComponentModel.ISupportInitialize)(this.numericIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelIN;
        private System.Windows.Forms.Label labelHN;
        private System.Windows.Forms.Label labelON;
        private System.Windows.Forms.Label labelSL;
        private System.Windows.Forms.NumericUpDown numericIN;
        private System.Windows.Forms.NumericUpDown numericHN;
        private System.Windows.Forms.NumericUpDown numericON;
        private System.Windows.Forms.NumericUpDown numericSL;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelLB;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
    }
}