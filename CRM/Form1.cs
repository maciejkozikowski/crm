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
            label1.Text = "Witaj! Dziś jest " + DateTime.Now.ToString();
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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

            ChangeLog changelogform = new ChangeLog();
            changelogform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void wyszukajKlientaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wyszukajKlienta wyszukajKlientaForm = new wyszukajKlienta();
            wyszukajKlientaForm.Show();
        }




    }



   

}

