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
        string idklienta;
        public KlientForm()
        {
            InitializeComponent();
            
        }
        //idklienta,imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak
        public void foo(string id,string imie,string nazwisko, string pesel,string adres_zam,string adres_kor, string telefon_kon,string email){
            
            this.Text = imie + " " + nazwisko;
            MessageBox.Show(id + imie + nazwisko + email);
            idklienta = id;
        }
    }
}
