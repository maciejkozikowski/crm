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

        public void foo(string a){
            MessageBox.Show(a);
            idklienta = a;
        }
    }
}
