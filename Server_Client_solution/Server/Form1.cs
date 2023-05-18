using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private static byte[] ip;
        private IPAddress LocalAddress;
        private TcpListener Server;
        private Socket connection;
        NetworkStream nStream;
        BinaryReader br;
        BinaryWriter bw;
        private string speaker;
        private string Message;
        public Form1()
        {
            InitializeComponent();
            speaker = "Server: ";
            ip = new byte[] { 127, 0, 0, 1 };
            LocalAddress = new IPAddress(ip);
            Server = new TcpListener(LocalAddress, 2525);

        }
    }
}
