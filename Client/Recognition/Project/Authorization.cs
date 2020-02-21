using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace Project
{
    public partial class Authorization : Form
    {
        const int PORT = 5006;
        const string ADDRESS = "127.0.0.1";

        public Authorization()
        {
            InitializeComponent();
        }

        public string login
        {
            get { return textBoxLog.Text; }
        }

        private void buttonSI_Click(object sender, EventArgs e)
        {
            if (textBoxLog.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("You must fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SendMessageFromSocket("1", textBoxLog.Text, textBoxPass.Text, PORT);
        }

        private void buttonSU_Click(object sender, EventArgs e)
        {
            if (textBoxLog.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("You must fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SendMessageFromSocket("0", textBoxLog.Text, textBoxPass.Text, PORT);
        }
       
        private void SendMessageFromSocket(string key, string login, string password, int port)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);

                string length = null;
                if (login.Length <= 9)
                {
                    length = "0" + login.Length;
                }
                else
                {
                    length = Convert.ToString(login.Length);
                }

                byte[] key_bytes = Encoding.UTF8.GetBytes(key);
                byte[] loginLen = Encoding.UTF8.GetBytes(length);
                byte[] login_bytes = Encoding.UTF8.GetBytes(login);
                byte[] info = new byte[3 + login.Length];

                key_bytes.CopyTo(info, 0);
                loginLen.CopyTo(info, 1);
                login_bytes.CopyTo(info, 3);
                stream.Write(info, 0, info.Length);
                writer.Write(password);

                byte[] rec = new byte[1];
                stream.Read(rec, 0, 1);
                string reply = Encoding.UTF8.GetString(rec, 0, 1);

                switch (reply)
                {
                    case "0":
                        MessageBox.Show("Your account has been successfully created!", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    case "1":
                        MessageBox.Show("This login is not available. Try another one!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    case "2":
                        MessageBox.Show("You have successfully logged in!", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        return;
                    case "3":
                        MessageBox.Show("Incorrect login or password!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                writer.Flush();
                writer.Close();
                reader.Close();
                stream.Close();
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
        }
    }
}
