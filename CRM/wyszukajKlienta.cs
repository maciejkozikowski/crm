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
        
        static string sql = "select idklienta from klient";
        MySqlDataAdapter adapter = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);
        DataSet DS = new DataSet();
        public static DataTable changes;
        

        public wyszukajKlienta()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.CellClick += dataGridView1_CellClick;
            this.FormClosing += WyszakajKlienta_FormClosing;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
            {
                SqlConnectionClass.myConnection.Open();
            }
            
            adapter.Fill(DS);           
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            sql = "select idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak from klient ";

            if (checkBox3.Checked)
            {
                if (checkBox1.Checked)
                {
                    checkBox1.Checked = false;
                    
                }
                    
                if (checkBox2.Checked)
                {
                    checkBox2.Checked = false;
                    
                }
                   // or nazwisko like '%" + "%'

                sql = "SELECT idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak FROM klient where imie like '%" + textBox3.Text + "%' or nazwisko like '%" + textBox3.Text + "%' or pesel like '%" + textBox3.Text + "%' or telefon_kon like '%" + textBox3.Text + "%' or email like '%" + textBox3.Text + "%'";
            }

            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                    sql = "select idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak from klient where imie ='" + textBox1.Text + "' and nazwisko ='" + textBox2.Text + "'";
                else
                    sql = "select idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak from klient where imie ='" + textBox1.Text + "'"; 

            }
            

            if (checkBox2.Checked)
            {
                if (checkBox1.Checked)
                    sql = "select idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak from klient where imie ='" + textBox1.Text + "' and nazwisko ='" + textBox2.Text + "'";
                else
                    sql = "select idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak from klient where nazwisko ='" + textBox2.Text + "'";

            }

            


            sql += ";";


            //adapter.Dispose();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);
            DataSet DS = new DataSet();

            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
            {
                SqlConnectionClass.myConnection.Open();
            }
            
            //wypelnia rubryczki danymi ;*
            adapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];

            //Jakies update w tabeli moze co, czy tak na odwal ?
            //To potrzebne do wykrywania zmian w tabeli zeby updatowac
            button1.Click += delegate
            {


                //DataTable changes = ((DataTable)dda1.DataSource).GetChanges();

                if (changes != null)
                {
                    try
                    {
                        if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
                        {
                            SqlConnectionClass.myConnection.Open();
                        }


                        MySqlCommandBuilder mcb = new MySqlCommandBuilder(adapter);
                        adapter.UpdateCommand = mcb.GetUpdateCommand();
                        adapter.Update(changes);
                        ((DataTable)dataGridView1.DataSource).AcceptChanges();
                        MessageBox.Show("Edycja przebiegła pomyślnie");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                    }

                }


            };

        }

        //Jesli zaznaczymy 3 checkbox reszta nie moze byc zaznaczona
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }


                
                
        }

        //Klikniecie na tabele przenosi do klient forma
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.ReadOnly == true)
            {
                //idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string imie = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string nazwisko = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string pesel = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string adres_zam = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                string adres_kor = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                string t_kon = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                string email = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                string z_przetw = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                string z_market = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                string z_fak = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
                {
                    KlientForm klientFormForm = new KlientForm();
                    klientFormForm.Show();
                    klientFormForm.foo(id, imie, nazwisko, pesel, adres_zam, adres_kor, t_kon, email, z_przetw, z_market, z_fak);
                }
            }           
            

        }

        //Czyszczenie
        private void WyszakajKlienta_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
        //Aktualizacja danych
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = !dataGridView1.ReadOnly;
            if (dataGridView1.ReadOnly == true)
            {
                label4.Text = "Tryb edycji: OFF";
            }
            else
                label4.Text = "Tryb edycji: ON";
        }

       


    }
}
