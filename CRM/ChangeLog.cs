using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace CRM
{
   public static class ChangeLog
    {

       public static void Form()
       {
           //int odleglosc = 25;
           // Create a new instance of the form.
           Form ListaKlientowForm = new Form();

           // Create two buttons to use as the accept and cancel buttons.
           Button button1 = new Button();




           //Button1 opcje
           button1.Text = "Zamknij"; // Set the text of button1 to "OK".
           button1.Location = new Point(10, 10); // Set the position of the button on the form.



           // Set the caption bar text of the form.   
           ListaKlientowForm.Text = "Ostatnie zmiany";
           // Display a help button on the form.
           ListaKlientowForm.HelpButton = true;
           // Define the border style of the form to a dialog box.
           ListaKlientowForm.FormBorderStyle = FormBorderStyle.FixedDialog;
           // Set the MaximizeBox to false to remove the maximize box.
           ListaKlientowForm.MaximizeBox = false;
           // Set the MinimizeBox to false to remove the minimize box.
           ListaKlientowForm.MinimizeBox = false;
           // Set the accept button of the form to button1.
           //ListaKlientowForm.AcceptButton = button1;
           // Set the cancel button of the form to button2.
           ListaKlientowForm.CancelButton = button1;
           // Set the start position of the form to the center of the screen.
           ListaKlientowForm.StartPosition = FormStartPosition.CenterScreen;

           // Add buttons to the form.
           ListaKlientowForm.Controls.Add(button1);
           //ListaKlientowForm.Controls.Add(button2); //Narazie niepotrzebne

           




           // Display the form as a modal dialog box.

           ListaKlientowForm.ShowDialog();





       }


    }
}
