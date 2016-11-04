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
        
       
        


        public Form1()
        {
            InitializeComponent();
            SqlConnectionClass.Foo();
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDodajKlienta_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO klient VALUES ('" + textBoxPesel.Text.ToString() + "', '" + textBoxImie.Text.ToString() + "', '" + textBoxNazwisko.Text.ToString() + "', '" + textBoxAdresZameldowania.Text.ToString() + "', '" + textBoxAdresKorespondencyjny.Text.ToString() + "', '" + textBoxTelefonKontaktowy.Text.ToString() + "', '" + textBoxEMail.Text.ToString() + "');";
                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MessageBox.Show(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
                toolStripStatusLabel1.Text = "Dodano klienta";


            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }


        }   
           

        private void buttonWyszukajPesel_Click(object sender, EventArgs e)
        {/*
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (SqlCommand command = new SqlCommand("select * from klient where pesel='" + textBoxPesel.Text.ToString() + "'", con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBoxPesel.Text = reader["pesel"].ToString();
                        textBoxImie.Text = reader["imie"].ToString();
                        textBoxNazwisko.Text = reader["nazwisko"].ToString();
                        textBoxAdresKorespondencyjny.Text = reader["adreskorespondencyjny"].ToString();
                        textBoxAdresZameldowania.Text = reader["adreszameldowania"].ToString();
                        textBoxTelefonKontaktowy.Text = reader["telefonkontaktowy"].ToString();
                        textBoxEMail.Text = reader["email"].ToString();
                    }
                }
            }*/
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }
    }



   

}

