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
        public DodajTelefon()
        {
            InitializeComponent();
            this.FormClosing += DodajTelefon_FormClosing;
        }

        private void DodajTelefon_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
        void CzytajAbonamenty()
        {
            string sql = "select id, nazwa, cenaabonament, cenazaminute, cenazasms, cenazamb from abonament";
            MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);

            List<Abonament> lista = new List<Abonament>();
            int i=0;
            MySqlDataReader rdr = new MySqlDataReader();
            while (rdr.Read())
            {
                lista.Add(new Abonament(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString()));
                comboBox1.Controls.Add(lista[i].nazwa);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

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
