using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Client_Side
{
    public partial class Form1 : Form
    {
        private static byte[] ip;
        private IPAddress LocalAddress;
        private TcpClient client;
        private NetworkStream nStream;
        private BinaryReader br;
        private BinaryWriter bw;
        private string speaker;
        private string Message;
        public Form1()
        {
            InitializeComponent();
            speaker = "Client 1: ";
            ip = new byte[] { 127, 0, 0, 1 };
            LocalAddress = new IPAddress(ip);
            client = new TcpClient();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Message = "Leaved";
            bw.Write(speaker + Message);
            listBox1.Items.Add(br.ReadString());
            br.Close();
            bw.Close();
            nStream.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client.Connect(LocalAddress, 2525);
            nStream = client.GetStream();
            bw = new BinaryWriter(nStream);
            br= new BinaryReader(nStream);
            Message = "Connected";
            bw.Write(speaker + Message);
            listBox1.Items.Add(br.ReadString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(br.ReadString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Message = textBox1.Text;
            bw.Write(speaker + Message);
            textBox1.Text = "";
        }
    }
}
