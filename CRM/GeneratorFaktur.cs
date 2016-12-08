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
        string wypis;
        public GeneratorFaktur(Faktura a)
        {   
            InitializeComponent();
            //LiczFaktury
            wypis += a.imieF + " " + a.nazwiskoF + Environment.NewLine;
            wypis += "" + a.adresF + Environment.NewLine;
            wypis += "Numer klienta: " + a.id + Environment.NewLine;            
            wypis += "Faktura: " +a.nazwafaktury + Environment.NewLine;

            string miesiac123;
            int i = 0;
            foreach (var telefon in a.listaTelefonow2)
            {
                wypis += Environment.NewLine + telefon.numer.ToString();
                wypis += Environment.NewLine + "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -";

                //MessageBox.Show("XD"); //test
                #region MiesiacRozmowyRegion
                //Ile jest numerow dlatego id
                string sql = "select czaspolaczen,oplata from miesiacrozmowy where numer =@numer and miesiac =@miesiac;";

                MySqlCommand cmd = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                miesiac123 = a.rok+"-"+a.miesiac;
                cmd.Parameters.AddWithValue("@miesiac", miesiac123);
                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr = cmd.ExecuteReader();
                a.rozmowy[i] = "0";
                a.rozmowycena[i] = "0";
                while (rdr.Read())
                {
                    a.rozmowy[i] = rdr[0].ToString();
                    a.rozmowycena[i] = rdr[1].ToString();
                }
                rdr.Close();
                wypis += Environment.NewLine + "Rozmowy: " + a.rozmowy[i] + " Koszt: " + a.rozmowycena[i] + "zł | "; 
                
                #endregion
                
                #region MiesiacSmsyRegion
                //Ile jest numerow dlatego id
                sql = "select smsy, oplata from miesiacsmsy where numer =@numer and miesiac =@miesiac;";

                MySqlCommand cmd1 = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);
                cmd1.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                cmd1.Parameters.AddWithValue("@miesiac", miesiac123);
                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr1 = cmd1.ExecuteReader();
                a.smsy[i] = "0";
                a.smsycena[i] = "0";
                while (rdr1.Read())
                {
                    a.smsy[i] = rdr1[0].ToString();
                    a.smsycena[i] = rdr1[1].ToString();
                }
                wypis += "SMS'y: " + a.smsy[i] + " Koszt: " + a.smsycena[i] + "zł | ";  
                rdr1.Close();
                #endregion
                #region MiesiacInternetRegion
                //Ile jest numerow dlatego id
                sql = "select MB, oplata from miesiacinternet where numer =@numer and miesiac =@miesiac;";

                MySqlCommand cmd2 = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);
                cmd2.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                cmd2.Parameters.AddWithValue("@miesiac", miesiac123);
                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr2 = cmd2.ExecuteReader();
                a.internet[i]="0";
                a.internetcena[i]="0";
                while (rdr2.Read())
                {
                    a.internet[i] = rdr2[0].ToString();
                    a.internetcena[i] = rdr2[1].ToString();
                }
                rdr2.Close();
                wypis += i + "Internet: " + a.internet[i] + " Koszt: " + a.internetcena[i] + "zł | "; 
                #endregion

                #region MiesiacAbonamentRegion
                //Ile jest numerow dlatego id
                sql = "SELECT a.cenaabonament FROM abonament a inner join telefon t on t.abonament=a.id where t.numer=@numer;";
                MySqlCommand cmd3 = new MySqlCommand(sql,
                   SqlConnectionClass.myConnection);

                cmd3.Parameters.AddWithValue("@numer", telefon.numer.ToString());
                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr3 = cmd3.ExecuteReader();
                a.abonament[i]="0";
                while (rdr3.Read())
                {

                    a.abonament[i] = rdr3[0].ToString();
                }
                rdr3.Close();
                wypis += "Abonament: " + a.abonament[i] + "zł "+Environment.NewLine;
                #endregion
                 
                i++;
                  
            }
            
            WypiszDoRicha();
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
