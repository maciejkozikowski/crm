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
    public partial class DodajTelefon : Form
    {
        List<Abonament> lista = new List<Abonament>();
        public string id;
        public DodajTelefon()
        {
            InitializeComponent();
            this.FormClosing += DodajTelefon_FormClosing;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            CzytajAbonamenty();
            textBox1.Text = "48";
        }

        private void DodajTelefon_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        void CzytajAbonamenty()
        {
            string sql = "select id, nazwa, cenaabonament, cenazaminute, cenazasms, cenazamb from abonament";
            MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);

            
            int i=0;
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new Abonament(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString()));
                comboBox1.Items.Add(lista[i].nazwa);
                i++;
            }
            rdr.Close();
            comboBox1.SelectedIndex = 0;
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into telefon (numer, idklienta, abonament) values(@numer, @idklienta, @abonament);";
            sql += "insert into pakietrozmowy values(@numer, current_timestamp(), current_timestamp()); ";
            sql += "insert into pakietsmsy values(@numer, current_timestamp(), current_timestamp()); ";
            sql += "insert into pakietinternet values(@numer, current_timestamp(), current_timestamp()); ";

            MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
            cmd.Parameters.AddWithValue("@numer", textBox1.Text);
            cmd.Parameters.AddWithValue("@idklienta", this.id);
            cmd.Parameters.AddWithValue("@abonament", lista[comboBox1.SelectedIndex].id);
            try
            {
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)                
                    SqlConnectionClass.myConnection.Open();
                
                MySqlDataReader rdr = cmd.ExecuteReader();
                MessageBox.Show("Dodano numer!");
                rdr.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                if (ex.Number == 1062)
                    MessageBox.Show("Taki numer już istnieje!");
                else
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }
        }
        public void JakieId(string id)
        {
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void ComboBox1_SelectedIndexChanged(object sender,
        System.EventArgs e)
        {
            int indexwybrany = comboBox1.SelectedIndex;
            label3.Text = "Abonament: "+lista[indexwybrany].cenaabonament+" zł";
            label4.Text = "Minuta: "+lista[indexwybrany].cenazaminute+" zł";
            label5.Text = "Sms: "+lista[indexwybrany].cenazasms + " zł";
            label6.Text = "MB: " +lista[indexwybrany].cenazamb + " zł";            
        }



    }
    public class Abonament
    {
        public string id, nazwa, cenaabonament, cenazaminute, cenazasms, cenazamb;
        public Abonament(string id, string nazwa, string cenaabonament, string cenazaminute, string cenazasms, string cenazamb)
        {
            this.id = id;
            this.nazwa = nazwa;
            this.cenaabonament = cenaabonament;
            this.cenazaminute = cenazaminute;
            this.cenazasms = cenazasms;
            this.cenazamb = cenazamb;
        }
        public Abonament() { }
    }
}
