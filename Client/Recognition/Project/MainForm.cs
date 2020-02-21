using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Project
{
    public partial class MainForm : Form
    {
        const int PORT = 5006;
        const string ADDRESS = "127.0.0.1";

        public MainForm()
        {
            InitializeComponent();

            buttonAdd.Enabled = false;
            buttonDelete.Enabled = false;
            buttonTrain.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authorization authorForm = new Authorization();
            if (authorForm.ShowDialog() == DialogResult.OK)
            {
                labelUser.Text = authorForm.login;
                labelUser.Location = new Point(663 - labelUser.Width, 61);
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = true;
                buttonTrain.Enabled = true;
                saveToolStripMenuItem.Enabled = true;

                if (System.IO.Directory.Exists(@"Networks"))
                {
                    System.IO.Directory.Delete(@"Networks", true);
                }
                dataGridView1.Rows.Clear();
                Download_Networks();
                authorForm.Close();
            }
        }

        private void Download_Networks()
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);

                string length = null;
                if (labelUser.Text.Length <= 9)
                {
                    length = "0" + labelUser.Text.Length;
                }
                else
                {
                    length = Convert.ToString(labelUser.Text.Length);
                }

                byte[] key = Encoding.UTF8.GetBytes("3");
                byte[] loginLen = Encoding.UTF8.GetBytes(length);
                byte[] login = Encoding.UTF8.GetBytes(labelUser.Text);
                byte[] info = new byte[3 + login.Length];

                key.CopyTo(info, 0);
                loginLen.CopyTo(info, 1);
                login.CopyTo(info, 3);
                stream.Write(info, 0, info.Length);

                string function = reader.ReadString();
                if (function == "0")
                {
                    stream.Flush();
                    stream.Close();
                    reader.Close();
                    return;
                }

                int bytesRead;
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int len = reader.ReadInt32();

                using (BinaryWriter wr = new BinaryWriter(new FileStream(@"Networks.zip", FileMode.Create)))
                {
                    int recieved = 0;
                    while (recieved < len)
                    {
                        bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                        recieved += bytesRead;
                        wr.Write(buffer, 0, bytesRead);
                        //Console.WriteLine("{0} bytes recieved.", recieved);
                    }
                }

                stream.Flush();
                stream.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }

            using (ZipFile zip = ZipFile.Read(@"Networks.zip"))
            {
                zip.ParallelDeflateThreshold = -1;
                foreach (ZipEntry e in zip)
                {
                    e.Extract("Networks", ExtractExistingFileAction.OverwriteSilently);
                }
            }

            System.IO.File.Delete(@"Networks.zip");
            Output_Networks(@"Networks");
        }

        private void Output_Networks(string Dir)
        {
            string name;
            int input_nodes, hidden_nodes, output_nodes;
            double speed_learning;
            List<string> flags = new List<string>();

            System.IO.DirectoryInfo DI = new System.IO.DirectoryInfo(Dir);
            System.IO.DirectoryInfo[] SubDir = DI.GetDirectories();
            for (int i = 0; i < SubDir.Length; ++i)
                this.Output_Networks(SubDir[i].FullName);
            System.IO.FileInfo[] FI = DI.GetFiles();
            for (int i = 0; i < FI.Length; ++i)
            {
                if (FI[i].Name == @"parameters.dat")
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(FI[i].FullName, FileMode.Open)))
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
                    dataGridView1.Rows.Add(name, input_nodes, 
                        hidden_nodes, output_nodes, speed_learning);

                    DataGridViewComboBoxCell comboBoxHeaderCell = new DataGridViewComboBoxCell();
                    dataGridView1[5, dataGridView1.RowCount - 2] = comboBoxHeaderCell;
                    comboBoxHeaderCell.Items.AddRange(flags.ToArray());
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("You must add a network!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (ZipFile zip = new ZipFile())
            {
                zip.ParallelDeflateThreshold = -1;
                zip.AddDirectory(@"Networks");
                zip.Save(@"Networks.zip");
            }

            string path = @"Networks.zip";
            FileInfo file = new FileInfo(path);

            TcpClient client = null;
            try
            {
                client = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);

                string length = null;
                if (labelUser.Text.Length <= 9)
                {
                    length = "0" + labelUser.Text.Length;
                }
                else
                {
                    length = Convert.ToString(labelUser.Text.Length);
                }

                byte[] key = Encoding.UTF8.GetBytes("2");
                byte[] loginLen = Encoding.UTF8.GetBytes(length);
                byte[] size = BitConverter.GetBytes(file.Length);
                byte[] login = Encoding.UTF8.GetBytes(labelUser.Text);
                byte[] info = new byte[3 + login.Length + size.Length];

                key.CopyTo(info, 0);
                loginLen.CopyTo(info, 1);
                login.CopyTo(info, 3);
                size.CopyTo(info, 3 + login.Length);
                stream.Write(info, 0, info.Length);

                byte[] buffer = new byte[1024 * 16];
                int count;

                long sended = 0;

                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                    while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, count);
                        sended += count;
                        Console.WriteLine("{0} bytes sended.", sended);
                    }

                stream.Flush();
                stream.Close();
                writer.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client != null)
                    client.Close();
            }

            System.IO.File.Delete(@"Networks.zip");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Networking networking = new Networking();
            if (networking.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Clear();
                Output_Networks(@"Networks");
                networking.Close();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You must select a row to delete it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string directoria = @"Networks\" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (System.IO.Directory.Exists(directoria))
            {
                Directory.Delete(directoria, true);
            }
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("You must select a row to train it!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Training train = new Training(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (train.ShowDialog() == DialogResult.OK)
            {
                train.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            string directoria = @"Networks";
            Directory.Delete(directoria, true);
            Application.Exit();
        }
    }
}
