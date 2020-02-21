using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace Project
{
    public partial class Training : Form
    {
        private bool draw;
        private Point start_point;
        private string projectName;
        private string name;
        private int input_nodes, hidden_nodes, output_nodes;
        private double speed_learning;
        private List<string> flags = new List<string>();
        private NeuralNetwork network;

        public Training(string pjname)
        {
            projectName = pjname;
            InitializeComponent();
            using (BinaryReader reader = new BinaryReader(File.Open(@"Networks\" + pjname + @"\parameters.dat", FileMode.Open)))
            {
                name = reader.ReadString();
                input_nodes = reader.ReadInt32();
                hidden_nodes = reader.ReadInt32();
                output_nodes = reader.ReadInt32();
                speed_learning = reader.ReadDouble();
                while (reader.PeekChar() != -1)
                {
                    flags.Add(reader.ReadString());
                }
            }
            comboFlags.Items.AddRange(flags.ToArray());
            network = new NeuralNetwork(name, input_nodes, hidden_nodes, output_nodes, speed_learning);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
        }

        private void buttonTeach_Click(object sender, EventArgs e)
        {
            if (comboFlags.SelectedIndex == -1)
            {
                MessageBox.Show("You must select the flag!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> img2vec = new List<string>();
            img2vec.Add(Convert.ToString(comboFlags.SelectedIndex));
            Bitmap original_image = new Bitmap(pictureBox1.Image);
            Bitmap squeezed_image = new Bitmap(original_image, new Size(original_image.Width / 7, original_image.Height / 7));
            for (int j = 0; j < squeezed_image.Height; j++)
                for (int i = 0; i < squeezed_image.Width; i++)
                {
                    float R = squeezed_image.GetPixel(i, j).R;
                    float G = squeezed_image.GetPixel(i, j).G;
                    float B = squeezed_image.GetPixel(i, j).B;

                    double value_of_pixel = (R + G + B) / 3.0;

                    img2vec.Add(Convert.ToString(255 - value_of_pixel));
                }

            string[] data_mas = img2vec.ToArray();
            string data = String.Join(",", data_mas);
            network.neural_network_training(data, comboFlags.Items.Count);
            clear_window();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            List<string> img2vec = new List<string>();
            Bitmap original_image = new Bitmap(pictureBox1.Image);
            Bitmap squeezed_image = new Bitmap(original_image, new Size(original_image.Width / 7, original_image.Height / 7));
            for (int j = 0; j < squeezed_image.Height; j++)
                for (int i = 0; i < squeezed_image.Width; i++)
                {
                    float R = squeezed_image.GetPixel(i, j).R;
                    float G = squeezed_image.GetPixel(i, j).G;
                    float B = squeezed_image.GetPixel(i, j).B;

                    double value_of_pixel = (R + G + B) / 3.0;

                    img2vec.Add(Convert.ToString(255 - value_of_pixel));
                }

            string[] data_mas = img2vec.ToArray();
            string data = String.Join(",", data_mas);

            int max = -1, index = -1, k = 0;
            int[] vec = network.neural_network_testing(data);
            foreach (int number in vec)
            {
                if (number > max)
                {
                    max = number;
                    index = k;
                    k++;
                }
                else
                    k++;
            }

            labelRespond.Text = comboFlags.Items[index].ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(SystemColors.Window);
            pictureBox1.Invalidate();
        }

        private void clear_window()
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(SystemColors.Window);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.FillEllipse(Brushes.Black, start_point.X, start_point.Y, 7, 7);
                    start_point = e.Location;
                    pictureBox1.Invalidate();
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw = true;
                start_point = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draw = false;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save your weights?", "Save", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                network.save_weights(projectName);
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
