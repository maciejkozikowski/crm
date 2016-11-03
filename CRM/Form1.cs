using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CRM
{
    public partial class Form1 : Form
    {
        public string connectionString = "Data Source=DESKTOP-M9RN1U7\\SQLEXPRESS;Initial Catalog=CRM;Integrated Security=True;Pooling=False";
    
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDodajKlienta_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            if (con.State==System.Data.ConnectionState.Open)
            {
                string q = "INSERT INTO klient VALUES ('" + textBoxPesel.Text.ToString() + "', '" + textBoxImie.Text.ToString() + "', '" + textBoxNazwisko.Text.ToString() + "', '" + textBoxAdresZameldowania.Text.ToString() + "', '" + textBoxAdresKorespondencyjny.Text.ToString() + "', '" + textBoxTelefonKontaktowy.Text.ToString() + "', '" + textBoxEMail.Text.ToString() + "');";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dodano klienta");
            }
        }

        private void buttonWyszukajPesel_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            using (SqlCommand command = new SqlCommand("select * from klient where pesel like '%" + textBoxPesel.Text.ToString() + "%'", con))
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
            }
        }
    }
}
