namespace Project
{
    partial class MainForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFlags = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.labelSI = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnInput,
            this.ColumnHidden,
            this.ColumnOutput,
            this.ColumnSpeed,
            this.ColumnFlags});
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(533, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnInput
            // 
            this.ColumnInput.HeaderText = "Input Nodes";
            this.ColumnInput.Name = "ColumnInput";
            this.ColumnInput.ReadOnly = true;
            this.ColumnInput.Width = 80;
            // 
            // ColumnHidden
            // 
            this.ColumnHidden.HeaderText = "Hidden Nodes";
            this.ColumnHidden.Name = "ColumnHidden";
            this.ColumnHidden.ReadOnly = true;
            this.ColumnHidden.Width = 80;
            // 
            // ColumnOutput
            // 
            this.ColumnOutput.HeaderText = "Output Nodes";
            this.ColumnOutput.Name = "ColumnOutput";
            this.ColumnOutput.ReadOnly = true;
            this.ColumnOutput.Width = 80;
            // 
            // ColumnSpeed
            // 
            this.ColumnSpeed.HeaderText = "Speed Learning";
            this.ColumnSpeed.Name = "ColumnSpeed";
            this.ColumnSpeed.ReadOnly = true;
            this.ColumnSpeed.Width = 80;
            // 
            // ColumnFlags
            // 
            this.ColumnFlags.HeaderText = "Flags";
            this.ColumnFlags.Name = "ColumnFlags";
            this.ColumnFlags.Width = 110;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(562, 109);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(97, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add network";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(562, 150);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(97, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete network";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(562, 191);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(97, 23);
            this.buttonTrain.TabIndex = 8;
            this.buttonTrain.Text = "Train network";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // labelSI
            // 
            this.labelSI.AutoSize = true;
            this.labelSI.Location = new System.Drawing.Point(588, 35);
            this.labelSI.Name = "labelSI";
            this.labelSI.Size = new System.Drawing.Size(74, 13);
            this.labelSI.TabIndex = 9;
            this.labelSI.Text = "User account:";
            this.labelSI.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelUser
            // 
            this.labelUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUser.AutoSize = true;
            this.labelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelUser.Location = new System.Drawing.Point(582, 61);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(78, 13);
            this.labelUser.TabIndex = 10;
            this.labelUser.Text = "Not Logged In!";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(669, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signInToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.signInToolStripMenuItem.Text = "Authorize";
            this.signInToolStripMenuItem.Click += new System.EventHandler(this.signInToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveToolStripMenuItem.Text = "Save All";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 251);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelSI);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label labelSI;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpeed;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnFlags;
    }
}