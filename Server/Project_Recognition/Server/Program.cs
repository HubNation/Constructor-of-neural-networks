using System;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        const int PORT = 5006;
        private static TcpListener listener;

        static void Main(string[] args)
        {
            IRepository repository = new UsersRepository();

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
                listener.Start();

                
                while (true)
                {
                    Console.WriteLine("Waiting for client connection...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client's been connected to the server.");

                    NetworkStream stream = client.GetStream();
                    BinaryWriter writer = new BinaryWriter(stream);
                    BinaryReader reader = new BinaryReader(stream);

                    byte[] buffer = new byte[client.ReceiveBufferSize];

                    int bytesRead = stream.Read(buffer, 0, 3);
                    if (bytesRead == 0) return;

                    string key = Encoding.UTF8.GetString(buffer, 0, 1);
                    string loginLen = Encoding.UTF8.GetString(buffer, 1, 2);
                    stream.Read(buffer, 0, Convert.ToInt32(loginLen));
                    string login = Encoding.UTF8.GetString(buffer, 0, Convert.ToInt32(loginLen));

                    if (key == "0")
                    {
                        string password = reader.ReadString();
                        
                        User user = new User();
                        int id = -1;

                        foreach (User u in repository.GetUsersList())
                        {
                            if (u.Login == login)
                                id = u.Id;
                        }

                        if (id == -1)
                        {
                            user.Login = login;
                            user.Password = password;
                            repository.Add(user);
                            repository.Save();

                            byte[] msg = Encoding.UTF8.GetBytes("0");
                            stream.Write(msg, 0, 1);
                        }
                        else
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("1");
                            stream.Write(msg, 0, 1);
                        }
                    }
                    else
                    if (key == "1")
                    {
                        string password = reader.ReadString();

                        User user = new User();
                        int id = -1;

                        foreach (User u in repository.GetUsersList())
                        {
                            if (u.Login == login && u.Password == password)
                                id = u.Id;
                        }

                        if (id != -1)
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("2");
                            stream.Write(msg, 0, 1);
                        }
                        else
                        {
                            byte[] msg = Encoding.UTF8.GetBytes("3");
                            stream.Write(msg, 0, 1);
                        }
                    }
                    else
                    if (key == "2")
                    {
                        User user = new User();
                        foreach (User u in repository.GetUsersList())
                        {
                            if (u.Login == login)
                                user = u;
                        }

                        stream.Read(buffer, 0, 8);
                        long len = BitConverter.ToInt64(buffer, 0);
                        user.Networks = new byte[len];
                        int recieved = 0;
                        while (recieved < len)
                        {
                            bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                            Array.Copy(buffer, 0, user.Networks, recieved, bytesRead);
                            recieved += bytesRead;
                        }
                        repository.Save();
                    }
                    else
                    if (key == "3")
                    {
                        User user = new User();
                        foreach (User u in repository.GetUsersList())
                        {
                            if (u.Login == login)
                                user = u;
                        }

                        if (user.Networks == null)
                        {
                            writer.Write("0");
                            continue;
                        }
                        else
                        {
                            writer.Write("1");
                        }

                        buffer = new byte[1024 * 16];
                        int size = user.Networks.Length, count = 1024 * 16, sended = 0;
                        writer.Write(size);

                        while (sended < size)
                        {
                            if (sended + count > size)
                            {
                                count = size - sended;
                            }
                            Array.Copy(user.Networks, sended, buffer, 0, count);
                            stream.Write(buffer, 0, count);
                            sended += count;
                        }
                    }

                    stream.Flush();
                    writer.Close();
                    reader.Close();
                    stream.Close();
                    client.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}
