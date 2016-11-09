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

        

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void dodajKlientaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DodajKlienta.Form();
           
        }

        private void oAutorachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oAutorach.foo();
        }

        private void listaKlientówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaKlientow.Form();
        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLog.Form();
        }




    }



   

}

