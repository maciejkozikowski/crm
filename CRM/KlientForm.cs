using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM
{
    public partial class KlientForm : Form
    {
        string id;
        string imie;
        string nazwisko;
        string pesel;
        string adres_zam;
        string adres_kor;
        string telefon_kon;
        string email;

        public KlientForm()
        {
            InitializeComponent();
            label3.Text = "Zalogowano jako: " + Program.userName + ", ostatnie logowanie: " + Program.userLastLogin;
            

        }
        //idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak
        public void foo(string id,string imie,string nazwisko, string pesel,string adres_zam,string adres_kor, string telefon_kon,string email){
            
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
            updateDane();
        }

        private void updateDane()
        {
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox1.ForeColor = Color.AliceBlue;
            
            label2.Text = listBox1.SelectedItem.ToString();
        }

        
    }
}
