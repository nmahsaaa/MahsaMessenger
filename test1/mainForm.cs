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
    public partial class mainForm : Form
    {
        TcpClient tcpclnt;
        SqlConnection Connection = new SqlConnection();
        SqlCommand Command = new SqlCommand();
        SqlDataReader reader;
        int portno;
        int res; 
        Dictionary<int, string> m_dic; 

        public mainForm(TcpClient t , int p , Dictionary<int , string> d , int r)
        {
            tcpclnt = t;
            InitializeComponent();
            portno = p;
            m_dic = d;
            res = r; 
        }
       

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Connection.ConnectionString = "Data Source=DESKTOP-7KANDJK; initial Catalog=contact; integrated Security = SSPI";
            Command.Connection = Connection;

            SqlCommand Command2 = new SqlCommand("select username , Name , FamilyName from Contacts", Connection);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Command2;
            DataTable dbt = new DataTable();
            sda.Fill(dbt);
            BindingSource bsource = new BindingSource();
          
            bsource.DataSource = dbt;
            dataGridView1.DataSource = bsource;
            sda.Update(dbt);



        }

        private void chatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            for (int i = 0 ; i < m_dic.Count ; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["Ports"].Value = m_dic.Keys.ElementAt(i);
                dataGridView1.Rows[i].Cells["Message"].Value = m_dic[i]; 
            }

        }

        private void toPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //this.Hide();
            messageform form3 = new messageform(tcpclnt , portno , res);
            form3.Closed += (s, args) => this.Close();
            form3.Show();
          //  break;
        }

        private void createGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
