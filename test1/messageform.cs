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

using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;


namespace test1 
{
    public partial class messageform : Form
    {
        TcpClient tcpclnt;
        SqlConnection Connection = new SqlConnection();
        SqlCommand Command = new SqlCommand();
        SqlDataReader reader;
        int portno;
        int res; 
        public messageform(TcpClient t , int p , int r)
        {
            tcpclnt = t;
            InitializeComponent();
            portno = p;
            res = r;
        }
        private void messageform_Load(object sender, EventArgs e)
        {
            Connection.ConnectionString = "Data Source=DESKTOP-7KANDJK; initial Catalog=contact; integrated Security = SSPI";
            Command.Connection = Connection;

            SqlCommand Command2 = new SqlCommand("select username , Name , FamilyName from Contacts where portnumber is not null", Connection);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = Command2;
                DataTable dbt = new DataTable();
                sda.Fill(dbt);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dbt;
                dataGridView1.DataSource = bsource;
                sda.Update(dbt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void button1_Click(object sender, EventArgs e) 
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter reciever ID");
            }
            else 
            {
                this.Hide();
                chat form2 = new chat(tcpclnt, textBox1.Text , portno , res);
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }

        private void textsts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

       
    }
}
