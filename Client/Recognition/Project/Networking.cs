using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Project
{
    public partial class Networking : Form
    {
        public Networking()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || numericIN.Value == 0 || numericHN.Value == 0
                || numericON.Value == 0 || numericSL.Value == 0
                || dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("You must fill all fields!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView.Rows.Count - 1 != (int)numericON.Value)
            {
                MessageBox.Show("The number of flags must be equal to the number of output nodes!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = textBoxName.Text;
            int input_nodes = (int)numericIN.Value,
                hidden_nodes = (int)numericHN.Value,
                output_nodes = (int)numericON.Value;
            double speed_learning = (double)numericSL.Value;
            List<string> flags = new List<string>();
            NeuralNetwork network = new NeuralNetwork(name, input_nodes, hidden_nodes, output_nodes, speed_learning);

            for (int i = 0; i < output_nodes; i++)
            {
                flags.Add(dataGridView[0, i].Value.ToString());
            }

            string dir = @"Networks\" + name;
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string path = dir + @"\parameters.dat";
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(name);
                writer.Write(input_nodes);
                writer.Write(hidden_nodes);
                writer.Write(output_nodes);
                writer.Write(speed_learning);
                foreach (string str in flags)
                {
                    writer.Write(str);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
