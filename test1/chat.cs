using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test1
{
    public partial class chat : Form
    {
        TcpClient tcpclnt;
        string reciever;
        int portno;
        int res; 
        public chat(TcpClient t , string r , int p , int ra)
        {
            
            InitializeComponent();
            reciever = r;
            tcpclnt = t;
            portno = p;
            res = ra; 
        }

        private void chat_Load(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public void button1_Click(object sender, EventArgs e)
        {
               // while (true) // baraye ferestadane dobare age ack bar nagasht
               // {
                    String str = portno.ToString() + '|' + reciever + '|' + richTextBox1.Text + '$';
                    NetworkStream stm = tcpclnt.GetStream();

                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str);
                    stm.Write(ba, 0, ba.Length);
                    stm.Flush();

                    //textsts.Text += Environment.NewLine + "Transmitting...";

                  /*  byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);
                    string Response = Encoding.ASCII.GetString(bb);
                    Response = Response.Substring(0, Response.IndexOf("$"));
                    //textsts.Text += Environment.NewLine + "Response from server: " + Response;*/

                    if (res == 1)
                    {

                        richTextBox2.AppendText("\r\n" + "- " + richTextBox1.Text + "\n *****************");
                        richTextBox2.ScrollToCaret();
                        richTextBox1.Text = "";
                        //break;
                    }
                    else if(res == 0)
                    {
                        MessageBox.Show("The username you entered was NOT VALID or ONLINE. \n Please Try Again Later!");
                        this.Hide();
                        messageform form2 = new messageform(tcpclnt , portno , res);
                        form2.Closed += (s, args) => this.Close();
                        form2.Show();
                       // break; 
                    }
                //}

            }
        public void Client_listener()
        {

        }
    }
}
