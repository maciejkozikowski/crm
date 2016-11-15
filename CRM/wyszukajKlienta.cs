using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRM
{
    public partial class wyszukajKlienta : Form
    {
        public wyszukajKlienta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //adapter.Dispose();
            string sql = "select * from klient";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);
            DataSet DS = new DataSet();

            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
            {
                SqlConnectionClass.myConnection.Open();
            }
            
            adapter.Fill(DS);
            
            
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sql = "select * from klient ";
            
            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                    sql = "select * from klient where imie ='" + textBox1.Text + "' and nazwisko ='" + textBox2.Text + "'";
                else
                    sql = "select * from klient where imie ='" + textBox1.Text + "'"; 

            }
            

            if (checkBox2.Checked)
            {
                if (checkBox1.Checked)
                    sql = "select * from klient where imie ='" + textBox1.Text + "' and nazwisko ='" + textBox2.Text + "'";
                else
                    sql = "select * from klient where nazwisko ='" + textBox2.Text + "'";

            }
           


            sql += ";";


            //adapter.Dispose();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);
            DataSet DS = new DataSet();

            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
            {
                SqlConnectionClass.myConnection.Open();
            }
            
            adapter.Fill(DS);


            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}
