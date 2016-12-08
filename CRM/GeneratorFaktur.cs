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
    public partial class GeneratorFaktur : Form
    {
        string wypis; //string do wpisania w richtextbox1, obraz faktury
        public GeneratorFaktur(Faktura a)
        {   
            InitializeComponent();
            //LiczFaktury
            //nagłówek faktury
            wypis += a.imieF + " " + a.nazwiskoF + Environment.NewLine;
            wypis += "" + a.adresF + Environment.NewLine;
            wypis += "Numer klienta: " + a.id + Environment.NewLine;            
            wypis += "Faktura: " +a.nazwafaktury + Environment.NewLine;
            float[] suma = new float[a.listaTelefonow2.Count]; //tablica sum opłat dla poszczególnych numerów
            float sumawszystko=0; //suma całej faktury
            string miesiac123; //określa miesiąc z faktury
            int i = 0; //index telefonu
            foreach (var telefon in a.listaTelefonow2) // wykonuje dla każdego telefonu konkretnego klienta
            {
                wypis += Environment.NewLine +"Numer telefonu: " +telefon.numer.ToString();
                wypis += Environment.NewLine + "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";
                miesiac123 = a.rok+"-"+a.miesiac;

                #region MiesiacRozmowyRegion liczenie opłat za rozmowy dla konkretnego numeru
                string sql = "select czaspolaczen,oplata from miesiacrozmowy where numer =@numer and miesiac =@miesiac;";

                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                cmd.Parameters.AddWithValue("@miesiac", miesiac123);
                //Czy jest polaczenie z baza ?
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    a.rozmowy[i] = "0"; //standardowo zera, jeśli nie było takiego połączenia w miesiącu, to opłata się nie pojawi i dupa
                    a.rozmowycena[i] = "0";
                    while (rdr.Read())
                    {
                        a.rozmowy[i] = rdr[0].ToString(); //pobiera ilość minut:sekund
                        a.rozmowycena[i] = rdr[1].ToString(); //pobiera kwotę naliczoną
                    }
                    rdr.Close();

                    wypis += Environment.NewLine + "Rozmowy: " + a.rozmowy[i] + " Koszt: " + a.rozmowycena[i] + "zł | " + Environment.NewLine; //eleganckie wypisanie opłat za rozmowy
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
                #endregion
                
                #region MiesiacSmsyRegion liczenie opłat za smsy
                sql = "select smsy, oplata from miesiacsmsy where numer =@numer and miesiac =@miesiac;";

                MySqlCommand cmd1 = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);
                cmd1.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                cmd1.Parameters.AddWithValue("@miesiac", miesiac123);
                try
                {

                //Czy jest polaczenie z baza ?
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    a.smsy[i] = "0"; //jw standardowo zera
                    a.smsycena[i] = "0";
                    while (rdr1.Read())
                    {
                        a.smsy[i] = rdr1[0].ToString();
                        a.smsycena[i] = rdr1[1].ToString();
                    }
                    wypis += "SMS'y: " + a.smsy[i] + " Koszt: " + a.smsycena[i] + "zł | " + Environment.NewLine;
                    rdr1.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
                #endregion

                #region MiesiacInternetRegion liczenie opłat za internet
                //Ile jest numerow dlatego id
                sql = "select MB, oplata from miesiacinternet where numer =@numer and miesiac =@miesiac;";

                MySqlCommand cmd2 = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);
                cmd2.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                cmd2.Parameters.AddWithValue("@miesiac", miesiac123);
                //Czy jest polaczenie z baza ?
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr2 = cmd2.ExecuteReader();
                    a.internet[i] = "0";
                    a.internetcena[i] = "0";
                    while (rdr2.Read())
                    {
                        a.internet[i] = rdr2[0].ToString();
                        a.internetcena[i] = rdr2[1].ToString();
                    }
                    rdr2.Close();
                    wypis += "Internet: " + a.internet[i] + " Koszt: " + a.internetcena[i] + "zł | " + Environment.NewLine;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
                #endregion

                #region MiesiacAbonamentRegion liczenie opłaty za abonament
                //Ile jest numerow dlatego id
                sql = "SELECT a.nazwa,a.cenaabonament FROM abonament a inner join telefon t on t.abonament=a.id where t.numer=@numer;";
                MySqlCommand cmd3 = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);

                cmd3.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                //Czy jest polaczenie z baza ?
                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                    {
                        SqlConnectionClass.myConnection.Open();
                    }
                    MySqlDataReader rdr3 = cmd3.ExecuteReader();
                    while (rdr3.Read())
                    {

                        a.abonament[i] = rdr3[0].ToString(); //dla odmiany to nie ilość a nazwa abonamentu
                        a.abonamentcena[i] = rdr3[1].ToString();
                    }
                    rdr3.Close();
                    wypis += "Abonament: " + a.abonament[i] + " Koszt: " + a.abonamentcena[i] + "zł " + Environment.NewLine;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }
                #endregion

                #region stopka opłat
                //suma opłat dla konkretnego telefonu
                suma[i] = float.Parse(a.rozmowycena[i]) + float.Parse(a.smsycena[i]) + float.Parse(a.internetcena[i]) + float.Parse(a.abonamentcena[i]);
                //suma opłat dla całej faktury
                sumawszystko += suma[i];
                //wypisanie sumy dla tego numeru
                wypis += "Suma: " + suma[i].ToString() +"zł"+ Environment.NewLine;
                i++;
                  
            }
            wypis += Environment.NewLine+"Suma faktury: " + sumawszystko+"zł"; // wypisanie sumy dla całej faktury
            WypiszDoRicha();
                #endregion
        }
        private void WypiszDoRicha()
        {
            richTextBox1.Text += wypis;
        }
        public GeneratorFaktur()
        {
            InitializeComponent();
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Poszło do drukowania (tak naprawde to nie lol)!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
