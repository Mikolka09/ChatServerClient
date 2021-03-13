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
using System.Threading;

namespace ChatServerClient
{
    public partial class Form1 : Form
    {
        public IPAddress iP;
        public IPEndPoint IPEnd;
        public Socket server;
        public Socket client;
        public int port = 1250;
        public List<string> answers;
        public BindingList<string> listMessages = new BindingList<string>();
        public Random rand;
        public string pathFile = @"d:\Users\MIKOLKA\ChatServerClient\ChatServerClient\BaseAnswers.txt";

        public Form1()
        {
            InitializeComponent();
            listMessages.ListChanged += ListMessages_ListChanged;
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
                    client.Send(buff);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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

        private void buttonTurnOnServer_Click(object sender, EventArgs e)
        {
            iP = IPAddress.Parse("127.0.0.1");
            IPEnd = new IPEndPoint(iP, port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Task.Run(() => ReciveMessage());
            if (MessageBox.Show("Сервер включен. Ожидаем подключения...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information) ==
                    DialogResult.OK)
                buttonTurnOnServer.Enabled = false;
        }

        public void ReciveMessage()
        {
            try
            {
                server.Bind(IPEnd);
                server.Listen(10);
                client = server.Accept();
                if (checkBoxAuto.Checked)
                    ListMessages_ListChanged(this, new ListChangedEventArgs(ListChangedType.ItemChanged, 0));
                while (client.Connected)
                {
                    byte[] data = new byte[1024];
                    client.Receive(data);
                    listMessages.Add(Encoding.Unicode.GetString(data));
                    if (listBoxReciveMessage.InvokeRequired)
                    {
                        listBoxReciveMessage.Invoke(new Action(() => listBoxReciveMessage.Items.Clear()));
                        foreach (var item in listMessages)
                        {
                            listBoxReciveMessage.Invoke(new Action(() => listBoxReciveMessage.Items.Add(item)));
                            listBoxReciveMessage.Invoke(new Action(() => listBoxReciveMessage.Items.Add("\n")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonSend.Enabled = false;
            BaseAnswers();
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
                    client.Send(buff);
                    textBoxSendMessage.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
            if (server != null)
                server.Close();
            if (client != null)
                client.Close();

        }

        private void textBoxSendMessage_TextChanged(object sender, EventArgs e)
        {
            buttonSend.Enabled = true;
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
