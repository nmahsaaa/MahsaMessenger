using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace test1
{
    public partial class LoginForm : Form
    {
        //public TcpClient tcpclnt;//= new TcpClient();
        public int PortNumber = new Random().Next(10000);
        public Dictionary<int, string> messageList = new Dictionary<int, string>();
        int res = 9; 
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        
        }

        public void button2_Click(object sender, EventArgs e)
        {
               TcpClient tcpclnt = new TcpClient(); 
               tcpclnt.Connect(IPAddress.Loopback, 8888);
   
                String str = textBox3.Text + ',' + textBox4.Text + ',' + PortNumber + '$';
                NetworkStream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] bb = asen.GetBytes(str);
                stm.Write(bb, 0, bb.Length);

                byte[] ba = new byte[100];
                int k = stm.Read(ba, 0, 100);
                string Response = Encoding.ASCII.GetString(ba);
                Response = Response.Substring(0, Response.IndexOf("$"));

                if (Response == "ack!")
                {
                    Listen contant_Listener = new Listen( tcpclnt , messageList , res);
                    Thread t = new Thread(() => contant_Listener.fillDict());
                    t.Start();

                    this.Hide();
                    mainForm form2 = new mainForm(tcpclnt , PortNumber , messageList , res);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                    //break;
                }
                else if (Response == "nack!")
                {
                    MessageBox.Show("Username or Password is incorrect. Have you forgotten your password?");
                    tcpclnt.Close();
                }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
      }
 }