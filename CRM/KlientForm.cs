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
    public partial class KlientForm : Form
    {
        public string id;
        public string imie;
        public string nazwisko;
        public string pesel;
        public string adres_zam;
        public string adres_kor;
        public string telefon_kon;
        public string email;
        public string z_przetw;
        public string z_market;
        public string z_fak;

        string wybranyNumer;

        public KlientForm()
        {
            InitializeComponent();
        }
       
        public void foo(string id,string imie,string nazwisko, string pesel,string adres_zam,string adres_kor, string telefon_kon,string email,string z_przetw, string z_market, string z_fak){
            
            this.Text = imie + " " + nazwisko;
            //MessageBox.Show(id + imie + nazwisko + email); // test czy dziala
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.pesel = pesel;
            this.adres_kor = adres_kor;
            this.adres_zam = adres_zam;
            this.telefon_kon = telefon_kon;
            this.email = email;
            this.z_przetw = z_przetw;
            this.z_market = z_market;
            this.z_fak = z_fak;


            updateDane();
            IleTelefonow();
            Faktura();

        }

        private void updateDane()
        {
            //
            label3.Text = "Zalogowano jako: " + Program.userName + ", ostatnie logowanie: " + Program.userLastLogin;

            //Labele, dane podstawowe
            label4.Text = "Imię i nazwisko: " + imie + " " + nazwisko;
            label5.Text = "Numer pesel: " + pesel;
            
            if (adres_kor != adres_zam)
            {
                label6.Text = "Adres korespondencyjny: " + adres_kor;
                label7.Text = "Adres zamieszkania: " + adres_zam;
            }
            else
            {
                label6.Text = "Adres korespondencyjny i zamieszkania: ";
                label7.Text = adres_kor;
            }
            label8.Text = "Telefon kontaktowy: " + telefon_kon;
            label9.Text = "Adres e-mail: " + email;


        }

        void IleTelefonow()
        {

            //Pobieranie liczby telefonow telefonów

            //
            int liczbaNumerow =0;
            string[] telefonyTablica = new string[100]; //np 2 ale to bez znaczenia

            try
            {   
                #region ileNumerowRegion
                //Ile jest numerow dlatego id
                string sql = "SELECT count(numer) FROM crmproject.telefon where idklienta = '" +  this.id.ToString() + "';";

                MySqlCommand cmd = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);

                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string temp;
                    temp =  rdr[0].ToString();
                    liczbaNumerow = Int32.Parse(temp);
                    
                }
                rdr.Close();
                telefonyTablica = new string [liczbaNumerow];
                #endregion
                #region listaNumerowRegion
                //Jakies sa numery dla tego id
                sql = "SELECT numer FROM crmproject.telefon where idklienta = '" + this.id.ToString() + "';";

                MySqlCommand cmd2 = new MySqlCommand(sql,SqlConnectionClass.myConnection);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();

                int i =0;

                while (rdr2.Read())
                {
                    telefonyTablica[i] = rdr2[0].ToString();
                    i++;
                    if (i > liczbaNumerow)
                        break;
                     
                }
                rdr2.Close();



            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }


            

            
            List<Telefon> listaTelefonow = new List<Telefon>();
            
            for (int i=0; i <liczbaNumerow;i++)
            {
                listaTelefonow.Add(new Telefon(telefonyTablica[i]));
                if(listaTelefonow[i].numer != null)
                listBox1.Items.Add(listaTelefonow[i].numer);
            }

            if (listBox1.Items.Count > 0)
                listBox1.SetSelected(0, true);
#endregion

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = listBox1.SelectedItem.ToString();
            wybranyNumer = listBox1.SelectedItem.ToString();
            StanKonta();

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        void StanKonta()
        {
            #region MiesiacRozmowyRegion
            //Ile jest numerow dlatego id
            string sql = "select oplata from miesiacrozmowy where numer ='" + wybranyNumer + "' and miesiac = '2016-12';";

            MySqlCommand cmd = new MySqlCommand(sql,
               SqlConnectionClass.myConnection);

            //Czy jest polaczenie z baza ?
            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
            {
                SqlConnectionClass.myConnection.Open();
            }
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
               label10.Text= "Rozmowy: " + rdr[0].ToString() + "zł";
            }
            rdr.Close();
            #endregion

            #region MiesiacSmsyRegion

            sql = "select oplata from miesiacsmsy where numer ='" + wybranyNumer + "' and miesiac = '2016-12';";
            MySqlCommand cmd2 = new MySqlCommand(sql,
               SqlConnectionClass.myConnection);
            MySqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                label11.Text = "Smsy: " + rdr2[0].ToString() + "zł";
            }
            rdr2.Close();
            #endregion

            #region MeisiacInternetRegion
            sql = "select oplata from miesiacinternet where numer ='" + wybranyNumer + "' and miesiac = '2016-12';";
            MySqlCommand cmd3 = new MySqlCommand(sql,
               SqlConnectionClass.myConnection);
            MySqlDataReader rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())
            {
                label12.Text = "Internet: " + rdr3[0].ToString() + "zł";
            }
            rdr3.Close();
            #endregion



        }

        void Faktura()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EdycjaKlienta obiekt = new EdycjaKlienta();
            obiekt.foo(this.id, this.imie, this.nazwisko, this.pesel, this.adres_zam, this.adres_kor, this.telefon_kon, this.email,this.z_przetw,this.z_market,this.z_fak);
            obiekt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajTelefon DodajTelefonForm = new DodajTelefon();
            DodajTelefonForm.JakieId(this.id);
            DodajTelefonForm.Show();
        }

    }
    public class Telefon
    {
        public string numer;
        public Telefon(string numer)
        {
            this.numer = numer;
        }

        public Telefon()
        {

        }

    }
    public class Faktury
    {

    }
   
}
