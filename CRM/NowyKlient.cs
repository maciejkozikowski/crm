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
    public partial class NowyKlient : Form
    {
        public NowyKlient()
        {
            InitializeComponent();

            //Niszczy obiekt po zamknięciu
            this.FormClosing += NowyKlient_FormClosing;

            //Tooltipy
            ToolTip checkTop1 = new ToolTip();
            checkTop1.SetToolTip(checkZgoda1, "Wyrażam zgodę na przetwarzanie moich danych osobowych" + Environment.NewLine + " dla potrzeb niezbędnych do realizacji świadczonych usług.");
                  
            ToolTip checkTop2 = new ToolTip();
            checkTop2.SetToolTip(checkZgoda2, "Wyrażam zgodę na przetwarzanie danych transmisyjnych " + Environment.NewLine + "dla celów marketingu usług telekomunikacyjnych. Dane będą przetwarzane w okresie obowiązywania umowy.");

            ToolTip checkTop3 = new ToolTip();
            checkTop3.SetToolTip(checkZgoda3, "Wyrażam zgodę na realizację dostarczania faktur " + Environment.NewLine + "za świadczone usługi drogą elektroniczną.");


        }

        //Funkcja generująca klientow randowmowo
        public void Generacja()
        {
            #region BazaDanychRegion
            string[] ImionaMeskieTablica = new string[] { 
                //Na litere A
                "Adam","Andrzej",
                "Marian", "Kamil", "Maciek", "Bartek", "Jan", "Paweł", "Józef" };
            string[] ImionaZenskieTablica = new string[] { 
                //A
               "Ada", "Adela", "Adelajda", "Adrianna", "Agata", "Agnieszka", "Aldona", "Aleksandra", "Alicja", "Alina", "Amanda", "Amelia", "Anastazja", "Andżelika", "Aneta", "Anita", "Anna", "Antonina",
               //B itd.
               "Barbara","Beata","Berenika","Bernadeta","Blanka","Bogusława","Bożena",
               "Cecylia","Celina","Czesława",
               "Dagmara","Danuta","Daria","Diana","Dominika","Dorota",
               "Edyta","Eliza","Elwira","Elżbieta"," Emilia","Eugenia","Ewa","Ewelina",
               "Felicja","Franciszka",
               "Gabriela","Grażyna",
               "Halina","Hanna","Helena",
               "Iga","Ilona","Irena","Irmina","Iwona","Izabela",
               "Jadwiga","Janina","Joanna","Jolanta","Jowita","Judyta","Julia","Julita","Justyna",
               "Kamila","Karina","Karolina","Katarzyna","Kazimiera","Kinga","Klaudia","Kleopatra","Kornelia","Krystyna",
               "Laura","Lena","Leokadia","Lidia","Liliana","Lucyna","Ludmiła","Luiza","Łucja",
               "Magdalena","Maja","Malwina","Małgorzata","Marcelina","Maria","Marianna","Mariola","Marlena","Marta","Martyna","Marzanna","Marzena","Matylda","Melania","Michalina","Milena","Mirosława","Monika",
               "Nadia","Natalia","Natasza","Nikola","Nina",
               "Olga","Oliwia","Otylia",
               "Pamela","Patrycja","Paula","Paulina",
               "Regina","Renata","Roksana","Róża","Rozalia",
               "Sabina","Sandra","Sara","Sonia","Stanisława","Stefania","Stella","Sylwia",
               "Tamara","Tatiana","Teresa",
               "Urszula",
               "Weronika","Wiesława","Wiktoria","Wioletta",
               "Zofia"," Zuzanna","Zyta","Żaneta" };

            string[] NazwiskaKoncowkiTablica = new string[] { "Kowalsk", "Sosnowsk", "Urbańsk", "Sowińsk", "Kozikowsk" };
            string[] NazwiskaTablica = new string[] { "Nowak", "Karolczak", "Stępień", "Krawczyk", "Wojtyła", "Pawlacz" };
            string[] AdresMiastoTablica = new string[]{ "Olsztyn", "Klebark", "Wadowice", "Łęczyca", "Sosnowiec","Klebark Mały", "Węgorzewo","Rybnice", "Radom", "Kraków" };
            string[] AdresUliceTablica = new string[] { "Kopernika", "Rataja", "Malborska", "Słoneczna", "Watykańska", "Kubusia Puchatka","Dywizjonu 303" };
            //string[,] array2Db = new string[,] { { "one", "two" }, { "three", "four" },{ "five", "six" } }; //moze sie przydac do przypisywania kodu pocztowego konkretnemu miastu

            string[] EmaileTablica = new string[] { "gmail.com", "wp.pl", "interia.pl", "outlook.com","yahoo.com" };
            int[] pesel = new int[11];
            #endregion

            //Stringi do wpisania w pola
            bool kobieta = true;
            string wybraneImie;
            string wybraneNazwisko;
            string wybranyEmail;
            string telefonWybrany = "48";
            string adresZamieszkaniaWybrany;
            string adresKorespondencyjnyWybrany;

            //Pora generować!!
            Random rnd = new Random();

            //Generujemy pesel   
            for (int i = 0; i < pesel.Length; i++)
            {
                pesel[i] = rnd.Next(0, pesel.Length - 1);
            }

            //jesli 10 liczba jest parzysta to kobieta + wybor imeinia
            if (pesel[9] % 2 == 0)
            {
                kobieta = true;
                //Wybór imienia
                wybraneImie = ImionaZenskieTablica[rnd.Next(ImionaZenskieTablica.Length )];
            }
            else
            {
                kobieta = false;
                //Wybór imienia
                wybraneImie = ImionaMeskieTablica[rnd.Next(ImionaMeskieTablica.Length )];
            }

            //Nazwiska z koncowkami ?? ski/ska?
            if (rnd.Next(2) == 1)
            {
                wybraneNazwisko = NazwiskaKoncowkiTablica[rnd.Next(NazwiskaKoncowkiTablica.Length )];
                if (kobieta)
                {
                    wybraneNazwisko += "a";
                }
                else
                {
                    wybraneNazwisko += "i";
                }
            }
            else
            {
                wybraneNazwisko = NazwiskaTablica[rnd.Next(NazwiskaTablica.Length )];
            }

            //Jakis email odrazu moze
            wybranyEmail = wybraneImie + "." + wybraneNazwisko + "@" + EmaileTablica[rnd.Next(EmaileTablica.Length )];

            //Lecimy z telefonem
            for (int i = 0; i < 9; i++)
            {
                telefonWybrany += rnd.Next(0, 10).ToString();
            }
            //Adresik np. rataja 54/16, 10-259 Olsztyn
            adresKorespondencyjnyWybrany = AdresUliceTablica[rnd.Next(AdresUliceTablica.Length)] + " " + rnd.Next(120).ToString() + "/" + rnd.Next(20).ToString() + ", " + rnd.Next(100).ToString() + "-" + rnd.Next(1000).ToString() + " " + AdresMiastoTablica[rnd.Next(AdresMiastoTablica.Length)];
            //Szansa ze jest taki sam jak zameldowania 1:5
            if(rnd.Next(5) == 4){
                adresZamieszkaniaWybrany = adresKorespondencyjnyWybrany;
            }
            else
                adresZamieszkaniaWybrany = AdresUliceTablica[rnd.Next(AdresUliceTablica.Length)] + " " + rnd.Next(120).ToString() + "/" + rnd.Next(20).ToString() + ", " + rnd.Next(100).ToString() + "-" + rnd.Next(1000).ToString() + " " + AdresMiastoTablica[rnd.Next(AdresMiastoTablica.Length)];
            //Czas wpisac w boxy
            imieTextBox.Text = wybraneImie;
            nazwiskoTextBox.Text = wybraneNazwisko;
            adresKorespondencyjnyTextBox.Text = adresKorespondencyjnyWybrany;
            adresZameldowaniaTextBox.Text = adresZamieszkaniaWybrany;            
            telefonTextBox.Text = telefonWybrany;
            eMailTextBox.Text = wybranyEmail;

            //pesel, moglem odrazu stringa zrobic lol
            peselTextBox.Text = "";
            for (int i = 0; i < pesel.Length; i++)
            {
                peselTextBox.Text += pesel[i].ToString();
            }
            //checkboxy
            if(rnd.Next(0,22)%2 ==0){
                checkZgoda1.Checked = true;
            }
            else
                checkZgoda1.Checked = false;

            if (rnd.Next(0, 22) % 3 == 0)
            {
                checkZgoda2.Checked = true;
            }
            else
                checkZgoda2.Checked = false;

            if (rnd.Next(0, 22) % 7 == 0)
            {
                checkZgoda3.Checked = true;
            }
            else
                checkZgoda3.Checked = false;

            if (rnd.Next(2137) == 1337)
            {
                MessageBox.Show("Wirus watykańczyk!");
            }


        }
        private void NowyKlient_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e) //Dodaj klienta przycisk
        {
                //button2.PerformClick(); //ma sie zamykac okno po dodaniu klienta?
                //dodajKlientaForm.Close(); //nie wiem ktory lepszy
                string checkstring1 = "0";
                string checkstring2 = "0";
                string checkstring3 = "0";
                if (checkZgoda1.Checked)
                    checkstring1 = "1";
                if (checkZgoda2.Checked)
                    checkstring2 = "1";
                if (checkZgoda3.Checked)
                    checkstring3 = "1";

                string sql = "INSERT INTO klient(imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak,data_utworzenia)";
                sql += " VALUES (@imie, @nazwisko, @pesel, @adres1, @adres2, @telefon, @email, '"
                + checkstring1 + "', '"
                + checkstring2 + "', '"
                + checkstring3 + "', CURDATE());";

                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@imie", imieTextBox.Text);
                cmd.Parameters.AddWithValue("@nazwisko", nazwiskoTextBox.Text);
                cmd.Parameters.AddWithValue("@pesel", peselTextBox.Text);
                cmd.Parameters.AddWithValue("@adres1", adresZameldowaniaTextBox.Text);
                cmd.Parameters.AddWithValue("@adres2", adresKorespondencyjnyTextBox.Text);
                cmd.Parameters.AddWithValue("@telefon", telefonTextBox.Text);
                cmd.Parameters.AddWithValue("@email", eMailTextBox.Text);

                try
                {
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    MessageBox.Show("Dodano klienta do bazy!");
                    rdr.Close();
                    button2.PerformClick();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }

        }

        private void button3_Click(object sender, EventArgs e) //Generuj!
        {
            Generacja();
        }

        private void button2_Click(object sender, EventArgs e) //Zamknij okienko
        {
            this.Dispose();
        }

       


    }
}
