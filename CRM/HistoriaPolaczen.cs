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
    public partial class HistoriaPolaczen : Form
    {
        string numer;
        
        public HistoriaPolaczen(string a)
        {
            InitializeComponent();
            this.numer = a;
            TabelaInternet();
            TabelaRozmowy();
            TabelaSMSy();
            this.FormClosing += HistoriaPolaczen_FormClosing;
            this.Text += numer;
        }
        //Pusty konstruktor
        public HistoriaPolaczen() 
        { 
        }

        void TabelaRozmowy()
        {
            string sql = "select numer, datapolaczenia, sec_to_time(czaspolaczenia) as czas_polaczenia, oplata from oplatazarozmowy  where numer = '" + numer + "' order by datapolaczenia desc;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);
            DataSet DS = new DataSet();
           
        
            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
            {
                SqlConnectionClass.myConnection.Open();
            }
            
            adapter.Fill(DS);           
            dataGridView1.DataSource = DS.Tables[0];
        }
        void TabelaSMSy()
        {
            string sql = "select numer, datapolaczenia, oplata from oplatazasmsy where numer = '" + numer + "' order by datapolaczenia desc;";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);
            DataSet DS = new DataSet();


            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
            {
                SqlConnectionClass.myConnection.Open();
            }

            adapter.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];
        }
        void TabelaInternet()
        {
            string sql = "select numer, datapolaczenia, round(internet/1024/1024,2) as MB, oplata from oplatazainternet where numer = '"+ numer +"' order by datapolaczenia desc;";
            MySqlDataAdapter cmd = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);            
            DataSet DS = new DataSet();
           
            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
            {
                SqlConnectionClass.myConnection.Open();
            }

            cmd.Fill(DS);
            dataGridView3.DataSource = DS.Tables[0];
        }
        private void HistoriaPolaczen_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

    }
}
