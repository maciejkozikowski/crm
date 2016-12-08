using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace CRM
{
    public partial class Form1 : Form
    {
        //Text wyśiwtlany domyślnie w polu czatu
        string defRichText = "Max 200 znaków.";
        
        //Inicjalizacja
        public Form1()
        {            
                InitializeComponent();
                SqlConnectionClass.Foo();
                label1.Text = "Witaj! Dziś jest " + DateTime.Now.ToString();
                this.Text = "CRM - Zalogowano jako: " + Program.userName;
                label2.Text = "Zalogowano jako: " + Program.userName + ", ostatnie logowanie: " + Program.userLastLogin;
                
                //czat
                richTextBox2.MaxLength = 200;
                //this.ActiveControl = richTextBox2; // ma byc aktywny na starcie czat, okienko do wpisywania
                richTextBox2.GotFocus += richTextBox2_GotFocus;
                richTextBox2.LostFocus += richTextBox2_LostFocus;
                richTextBox2.Text = defRichText;
                richTextBox2.ForeColor = Color.LightGray;
                Ostatnie();

        }

        //Czy użytkownik chce coś na czacie napisać?
        private void richTextBox2_GotFocus(object sender, EventArgs e)
        {
            richTextBox2.ForeColor = Color.Black;
            if(richTextBox2.Text == defRichText)
            richTextBox2.Text = "";
        }
        private void richTextBox2_LostFocus(object sender, EventArgs e)
        {

            if (richTextBox2.Text == "")
            {
                richTextBox2.ForeColor = Color.LightGray;
                richTextBox2.Text = defRichText;
            }
                
        }
        //?
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        //Czat 
        public void chat()
        {
            if (richTextBox2.Text != "" && richTextBox2.Text != defRichText)
            {                
                    string msg = "INSERT INTO wiadomosci(iduser,wiadomosc,datawiadomosci) VALUES (@id, @rich @line, CURTIME() + INTERVAL 8 HOUR);";
                    MySqlCommand cmd = new MySqlCommand(msg, SqlConnectionClass.myConnection);
                    cmd.Parameters.AddWithValue("@id", Program.userId);
                    cmd.Parameters.AddWithValue("@rich", richTextBox2.Text);
                    cmd.Parameters.AddWithValue("@line", System.Environment.NewLine);

                try
                {
                    if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??                    
                        SqlConnectionClass.myConnection.Open();

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                }

                richTextBox1.Text += Program.userName + ": " + richTextBox2.Text + System.Environment.NewLine;
            }

            richTextBox2.Text = defRichText;
        }
        //Co ostatnio edytowal/robił
        public void Ostatnie()
        {

        }
        void chatRefresh()
        {
            
            try
            {
                string refre = "SELECT users.name, wiadomosci.datawiadomosci, wiadomosci.wiadomosc FROM wiadomosci JOIN users ON wiadomosci.iduser = users.id";

                MySqlCommand cmd = new MySqlCommand(refre, SqlConnectionClass.myConnection);

                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??              
                    SqlConnectionClass.myConnection.Open();

                MySqlDataReader rdr = cmd.ExecuteReader();
                richTextBox1.Clear();

                while (rdr.Read())
                {
                    int j = 0; 
                    richTextBox1.Text += rdr[j] + " (" + rdr[j + 1] + "): " + rdr[j + 2 ];
                }
                    
                rdr.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }
        }        

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void dodajKlientaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NowyKlient NowyKlientForm = new NowyKlient();
            NowyKlientForm.Show();           
        }

        private void oAutorachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oAutorach.foo();
        }

        private void listaKlientówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaKlientow.Form();
        }        

        private void label1_Click(object sender, EventArgs e) // ??
        {

        }

        private void wyszukajKlientaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wyszukajKlienta wyszukajKlientaForm = new wyszukajKlienta();
            wyszukajKlientaForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("jakies drukowanie bedzie tu");
        }

        private void pictureBox1_Click(object sender, EventArgs e) //Dodawania klienta
        {
            NowyKlient NowyKlientForm = new NowyKlient();
            NowyKlientForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            wyszukajKlienta wyszukajKlientaForm = new wyszukajKlienta();
            wyszukajKlientaForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chatRefresh();
        }
    }

}

