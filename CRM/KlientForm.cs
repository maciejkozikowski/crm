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
        int wybranaFaktura = -1;
        public List<Faktura> listaFaktur = new List<Faktura>();
        public List<Telefon> listaTelefonow = new List<Telefon>();
        public string[] telefonyTablica = new string[]{};
        public KlientForm()
        {
            InitializeComponent();
            listBox2.SelectedIndexChanged +=listBox2_SelectedIndexChanged;

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

        public void updateDane()
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

            #region pakietrozmowy

            sql = "SELECT count(dataaktywacji)-count(datadezaktywacji) FROM pakietrozmowy where numer =@numer";
            MySqlCommand cmd4 = new MySqlCommand(sql, SqlConnectionClass.myConnection);
            cmd4.Parameters.AddWithValue("@numer", wybranyNumer);
            try
            {
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr4 = cmd4.ExecuteReader();
                while (rdr4.Read())
                {
                    if (rdr4[0].ToString() == "0")
                        label16.Text = "Wyłączony";
                    else
                        label16.Text = "Włączony";
                    break;
                }
                rdr4.Close();
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }

            #endregion

            #region pakietsmsy

            sql = "SELECT count(dataaktywacji)-count(datadezaktywacji) FROM pakietsmsy where numer =@numer";
            MySqlCommand cmd5 = new MySqlCommand(sql, SqlConnectionClass.myConnection);
            cmd5.Parameters.AddWithValue("@numer", wybranyNumer);
            try
            {
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr5 = cmd5.ExecuteReader();
                while (rdr5.Read())
                {
                    if (rdr5[0].ToString() == "0")
                        label17.Text = "Wyłączony";
                    else
                        label17.Text = "Włączony";
                    break;
                }
                rdr5.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }

            #endregion

            #region pakietinternet
            sql = "SELECT count(dataaktywacji)-count(datadezaktywacji) FROM pakietinternet where numer =@numer";
            MySqlCommand cmd6 = new MySqlCommand(sql, SqlConnectionClass.myConnection);
            cmd6.Parameters.AddWithValue("@numer", wybranyNumer);
            try
            {
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr6 = cmd6.ExecuteReader();
                while (rdr6.Read())
                {
                    if (rdr6[0].ToString() == "0")
                        label18.Text = "Wyłączony";
                    else
                        label18.Text = "Włączony";
                    break;
                }
                rdr6.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }
            #endregion

        }

       public void Faktura()
        {

            string value = DateTime.Today.Year +"-"+ DateTime.Today.Month; //tu pobiera rok pocztek 

            string sql = "SELECT concat(year(startuslugi),'-',month(startuslugi)) FROM telefon where idklienta=@id order by startuslugi limit 1;";

            MySqlCommand cmd = new MySqlCommand(sql,
               SqlConnectionClass.myConnection);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {

                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    value = rdr[0].ToString();
                }
                rdr.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }
            char delimiter = '-';
            string[] substrings = value.Split(delimiter);
            int rok = 1;
            int miesiac= 1;
            foreach (var substring in substrings)
            {
                rok = Int32.Parse(substrings[0]);
                miesiac = Int32.Parse(substrings[1]);
            }


            #region lista faktur
            while (true){
                if (rok == DateTime.Today.Year && miesiac == DateTime.Today.Month)
                {
                    break;
                }

                listaFaktur.Add(new Faktura(rok, miesiac, id, listaTelefonow, imie, nazwisko, adres_kor));

                if (miesiac < 12)
                    miesiac++;
                else
                {
                    miesiac = 1;
                    rok++;
                }
                
                
            }

            foreach (var i in listaFaktur)
            {
                listBox2.Items.Add(i.nazwafaktury);
            }
            #endregion

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
        //ustawianie pakietu darmowe rozmowy
        private void button4_Click(object sender, EventArgs e)
        {
            if (label16.Text == "Włączony")
            {
                string sql = "update pakietrozmowy set datadezaktywacji=current_timestamp() + interval 8 hour where numer=@numer and datadezaktywacji is null;";
                MySqlCommand cmd7 = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd7.Parameters.AddWithValue("@numer", wybranyNumer);
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr7 = cmd7.ExecuteReader();
                    MessageBox.Show("Wyłączono pakiet");
                    rdr7.Close();
                    label16.Text = "Wyłączony";

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
            }
            else
            {
                string sql = "insert into pakietrozmowy (numer,dataaktywacji) values (@numer, current_timestamp() + interval 8 hour);";
                MySqlCommand cmd8 = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd8.Parameters.AddWithValue("@numer", wybranyNumer);
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr8 = cmd8.ExecuteReader();
                    MessageBox.Show("Włączono pakiet");
                    rdr8.Close();
                    label16.Text = "Włączony";

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
            }
        } 
        //ustawianie pakietu darmowe smsy
        private void button5_Click(object sender, EventArgs e)
        {
            if (label17.Text == "Włączony")
            {
                string sql = "update pakietsmsy set datadezaktywacji=current_timestamp() + interval 8 hour where numer=@numer and datadezaktywacji is null;";
                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@numer", wybranyNumer);
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    MessageBox.Show("Wyłączono pakiet");
                    rdr.Close();
                    label17.Text = "Wyłączony";

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
            }
            else
            {
                string sql = "insert into pakietsmsy (numer,dataaktywacji) values (@numer, current_timestamp() + interval 8 hour);";
                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@numer", wybranyNumer);
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    MessageBox.Show("Włączono pakiet");
                    rdr.Close();
                    label17.Text = "Włączony";

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
            }
        }
        //ustawianie pakietu darmowy internet
        private void button6_Click(object sender, EventArgs e)
        {
            if (label18.Text == "Włączony")
            {
                string sql = "update pakietinternet set datadezaktywacji=current_timestamp() + interval 8 hour where numer=@numer and datadezaktywacji is null;";
                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@numer", wybranyNumer);
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    MessageBox.Show("Wyłączono pakiet");
                    rdr.Close();
                    label18.Text = "Wyłączony";

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
            }
            else
            {
                string sql = "insert into pakietinternet (numer,dataaktywacji) values (@numer,current_timestamp() + interval 8 hour);";
                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@numer", wybranyNumer);
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    MessageBox.Show("Włączono pakiet");
                    rdr.Close();
                    label18.Text = "Włączony";

                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            wybranaFaktura = listBox2.SelectedIndex;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (wybranaFaktura != -1)
            {
                GeneratorFaktur genFakForm = new GeneratorFaktur(listaFaktur[wybranaFaktura]);
                genFakForm.Show();
            }
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
    public class Faktura :KlientForm
    {
       public List<Telefon> listaTelefonow2; 
       public string nazwafaktury, imieF, nazwiskoF, adresF;
       public int rok, miesiac;
        //tablice przechowujące wielkość aktywności i opłaty (dla abo nazwa/oplata)
       public string[] abonament;
       public string[] abonamentcena;
       public string[] rozmowy;
       public string[] rozmowycena;
       public string[] smsy;
       public string[] smsycena;
       public string[] internet;
       public string[] internetcena;

        public Faktura(int rok,int miesiac, string id, List<Telefon> a, string imie, string nazwisko, string adres_kor)
        {
            this.rok = rok;
            this.miesiac = miesiac;
            this.id = id;
            this.nazwafaktury = "F" + id + "/" + rok + "/" + miesiac;
            this.listaTelefonow2 = a;
            this.imieF = imie;
            this.nazwiskoF = nazwisko;
            this.adresF = adres_kor;
            abonament = new string[a.Count];
            abonamentcena = new string[a.Count];
            rozmowy = new string[a.Count];
            rozmowycena = new string[a.Count];
            smsy = new string[a.Count];
            smsycena = new string[a.Count];
            internet = new string[a.Count];
            internetcena = new string[a.Count];
        }
        public Faktura()
        {

        }
        

    }
   
}
