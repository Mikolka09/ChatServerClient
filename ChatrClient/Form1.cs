using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace ChatrClient
{
    public partial class Form1 : Form
    {
        public IPAddress iP;
        public IPEndPoint IPEnd;
        public Socket socket;
        public int port;
        public List<string> answers;
        public BindingList<string> listMessages = new BindingList<string>();
        public Random rand;
        public string pathFile = @"d:\Users\MIKOLKA\ChatServerClient\ChatServerClient\BaseAnswers.txt";

        public Form1()
        {
            InitializeComponent();
            listMessages.ListChanged += ListMessages_ListChanged;
        }

        public void BaseAnswers()
        {
            answers = new List<string>();
            using (StreamReader sr = new StreamReader(pathFile, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    answers.Add(sr.ReadLine());
                }
            }
        }

        private void ListMessages_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (checkBoxAuto.Checked)
            {
                try
                {
                    Thread.Sleep(1000);
                    rand = new Random();
                    string message = answers[rand.Next(0, answers.Count)];
                    byte[] buff = new byte[1024];
                    buff = Encoding.Unicode.GetBytes(message);
                    socket.Send(buff);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaseAnswers();
            buttonSend.Enabled = false;
        }

        public void ConnectServer()
        {
            IPEnd = new IPEndPoint(iP, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(IPEnd);
                if (MessageBox.Show("Подключение к серверу прошло успешно!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) ==
                 DialogResult.OK)
                {
                    buttonConnection.Enabled = false;
                    buttonSend.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(checkBoxAuto.Checked)
                ListMessages_ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemChanged, 0));

            Task.Run(() =>
            {
                try
                {
                    while (socket.Connected)
                    {
                        byte[] data = new byte[1024];
                        socket.Receive(data);
                        listMessages.Add(Encoding.Unicode.GetString(data));
                        listBoxReciveMessage.Items.Clear();
                        foreach (var item in listMessages)
                        {
                            listBoxReciveMessage.Items.Add(item);
                            listBoxReciveMessage.Items.Add("\n");
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            Regex regIp = new Regex(@"(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
            string ipAdress = textBoxIp.Text;
            if (regIp.IsMatch(ipAdress))
            {
                if (ipAdress == "127.0.0.1")
                    iP = IPAddress.Parse(ipAdress);
                else
                {
                    MessageBox.Show("Неправильный IP - Адреса!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Неправильный формат IP-Адреса!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Regex regPort = new Regex(@"[0-9]{4}");
            string prt = textBoxPort.Text;
            if (regPort.IsMatch(prt))
            {
                if (Convert.ToInt32(prt) == 1250)
                    port = Convert.ToInt32(prt);
                else
                {
                    MessageBox.Show("Неправильный Порт!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неправильный формат Порта!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConnectServer();
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!checkBoxAuto.Checked)
            {

                try
                {
                    string message = textBoxSendMessage.Text;
                    byte[] buff = new byte[1024];
                    buff = Encoding.Unicode.GetBytes(message);
                    socket.Send(buff);
                    textBoxSendMessage.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBoxSendMessage_TextChanged(object sender, EventArgs e)
        {
            buttonSend.Enabled = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
            if (socket != null)
                socket.Close();
        }

        private void checkBoxAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAuto.Checked)
            {
                textBoxSendMessage.Enabled = false;
                buttonSend.Enabled = false;
            }
            else
            {
                textBoxSendMessage.Enabled = true;
                buttonSend.Enabled = true;
            }
        }
    }
}
