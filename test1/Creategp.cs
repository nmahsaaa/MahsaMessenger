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
    public partial class Creategp : Form
    {
        SqlConnection Connection = new SqlConnection();
        SqlCommand Command = new SqlCommand();
        SqlDataReader reader;

        public Dictionary<IPAddress, List<int>> gpList; 
        public Creategp(SqlConnection sc)
        {
            Connection = sc;
            InitializeComponent(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string member_id = textBox3.Text;

            //show online users in datagridview
            SqlCommand Command = new SqlCommand("select username , Name , FamilyName from Contacts where portnumber is not null"
                                                , Connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Command;
            DataTable dbt = new DataTable();
            sda.Fill(dbt);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbt;
            dataGridView1.DataSource = bsource;
            sda.Update(dbt);



            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
