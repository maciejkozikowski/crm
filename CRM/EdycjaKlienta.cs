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
    public partial class EdycjaKlienta : Form
    {
        public string idklienta;
        string z_przetw ="0", z_market="0", z_fak="0";
        public EdycjaKlienta()
        {
            InitializeComponent();
            this.FormClosing += EdycjaKlienta_FormClosing;
        }
        //obiekt.foo(this.id, this.imie, this.nazwisko, this.pesel, this.adres_zam, this.adres_kor, this.telefon_kon, this.email);
        public void foo(string id, string imie, string nazwisko, string pesel, string adres_zam, string adres_kor, string telefon_kon, string email, string z_przetw, string z_market, string z_fak)
        {
            textBox1.Text = imie;
            textBox2.Text = nazwisko;
            textBox3.Text = pesel;
            textBox4.Text = adres_zam;
            textBox5.Text = adres_kor;
            textBox6.Text = telefon_kon;
            textBox7.Text = email;
            this.idklienta = id;
            if (z_przetw != "0")
                checkBox1.Checked = true;
            if (z_market != "0")
                checkBox2.Checked = true;
            if (z_fak != "0")
                checkBox3.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak,data_utworzenia
            string sql = "update klient set imie=@imie, nazwisko=@nazwisko, pesel=@pesel, adres_zam=@adres_zam, adres_kor=@adres_kor, telefon_kon=@telefon_kon, email=@email, z_przetw=@z_przetw, z_market=@z_market, z_fak=@z_fak where idklienta=@idklienta;";
           MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
           cmd.Parameters.AddWithValue("@imie", textBox1.Text);
           cmd.Parameters.AddWithValue("@nazwisko", textBox2.Text);
           cmd.Parameters.AddWithValue("@pesel", textBox3.Text);
           cmd.Parameters.AddWithValue("@adres_zam", textBox4.Text);
           cmd.Parameters.AddWithValue("@adres_kor", textBox5.Text);
           cmd.Parameters.AddWithValue("@telefon_kon", textBox6.Text);
           cmd.Parameters.AddWithValue("@email", textBox7.Text);
           if (checkBox1.Checked)
               this.z_przetw = "1";
           if (checkBox2.Checked)
               this.z_market = "1";
           if (checkBox3.Checked)
               this.z_fak = "1";
           cmd.Parameters.AddWithValue("@z_przetw",this.z_przetw);
           cmd.Parameters.AddWithValue("@z_market",this.z_market);
           cmd.Parameters.AddWithValue("@z_fak",this.z_fak);
           cmd.Parameters.AddWithValue("@idklienta", this.idklienta);
           try
           {
               if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
               {
                   SqlConnectionClass.myConnection.Open();
               }
               MySqlDataReader rdr = cmd.ExecuteReader();
               MessageBox.Show("Edytowano klienta!");
               rdr.Close();
           }
           catch (MySql.Data.MySqlClient.MySqlException ex)
           {
               MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
           }

        }

        private void EdycjaKlienta_FormClosing(Object sender, FormClosingEventArgs e)
        {
            
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             Dispose();        
        }

    }
}
