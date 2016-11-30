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
    public partial class Logowanie : Form
    {
        public Logowanie()
        {
            InitializeComponent();
            textBox2.PasswordChar = '#';
            this.ActiveControl = textBox1;
            textBox2.KeyDown += textBox2_KeyDown;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Program.Logowanie(textBox1.Text,textBox2.Text);
            if(Program.zalogowano == true){
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

    }//koniec klasy
}
