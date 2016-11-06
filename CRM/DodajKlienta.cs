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
   public static class DodajKlienta
    {

       public static void Form()
       {
            int odleglosc = 25;

           // Create a new instance of the form.
           Form dodajKlientaForm = new Form();
          
           //Labele, co wpiswac
           Label imieLabel = new Label();
           Label nazwiskoLabel = new Label();
           Label peselLabel = new Label();
           Label adresZameldowaniaLabel = new Label();
           Label adresKorespondencyjnyLabel = new Label();
           Label telefonLabel = new Label();
           Label eMailLabel = new Label();
           //TextBoxy 
           TextBox imieTextBox = new TextBox();
           TextBox nazwiskoTextBox = new TextBox();
           TextBox peselTextBox = new TextBox();
           TextBox adresZameldowaniaTextBox = new TextBox();
           TextBox adresKorespondencyjnyTextBox = new TextBox();
           TextBox telefonTextBox = new TextBox();
           TextBox eMailTextBox = new TextBox();




           //imieLabel opcje
           imieLabel.Text = "Imię";
           imieLabel.Location = new Point(10, 10);
           //nazwiskoLabel opcje
           nazwiskoLabel.Text = "Nazwisko";
           nazwiskoLabel.Location = new Point(imieLabel.Left, imieLabel.Height + imieLabel.Top );
           //peselLabel opcje
           peselLabel.Text = "Numer pesel";
           peselLabel.Location = new Point(nazwiskoLabel.Left, nazwiskoLabel.Height + nazwiskoLabel.Top );
           //adresZameldowaniaLabel opcje
           adresZameldowaniaLabel.Text = "Adres zameldowania";
           adresZameldowaniaLabel.Location = new Point(peselLabel.Left, peselLabel.Height + peselLabel.Top );
           adresZameldowaniaLabel.AutoSize = true;
           //adresKorespondencyjnyLabel opcje
           adresKorespondencyjnyLabel.Text = "Adres korespondencyjny";
           adresKorespondencyjnyLabel.Location = new Point(adresZameldowaniaLabel.Left, adresZameldowaniaLabel.Height + adresZameldowaniaLabel.Top );
           adresKorespondencyjnyLabel.AutoSize = true;
           //telefonLabel opcje
           telefonLabel.Text = "Numer telefonu";
           telefonLabel.Location = new Point(adresKorespondencyjnyLabel.Left, adresKorespondencyjnyLabel.Height + adresKorespondencyjnyLabel.Top );
           //eMailLabel opcje
           eMailLabel.Text = "E-Mail";
           eMailLabel.Location = new Point(telefonLabel.Left, telefonLabel.Height + telefonLabel.Top );


           //imieTextBox opcje
           imieTextBox.Location = new Point(imieLabel.Right + odleglosc, 0 + imieLabel.Top);
           //nazwiskoTextBox opcje
           nazwiskoTextBox.Location = new Point(imieTextBox.Left, imieTextBox.Height + imieTextBox.Top);
           //peselTextBox opcje
           peselTextBox.Location = new Point(nazwiskoTextBox.Left, nazwiskoTextBox.Height + nazwiskoTextBox.Top);



           // Create two buttons to use as the accept and cancel buttons.
           Button button1 = new Button();
           Button button2 = new Button();
           button1.Click += delegate
           {
               MessageBox.Show("blablabla wykonuje sie niby, tak naprawde to nic sie nie dzieje bo trzeba dokonczyc kod, lololol");
               //button2.PerformClick(); //ma sie zamykac okno po dodaniu klienta?
               //dodajKlientaForm.Close(); //nie wiem ktory lepszy
           };
           
           
           //Button1 opcje
           button1.Text = "Dodaj"; // Set the text of button1 to "OK".
           button1.Location = new Point(eMailLabel.Left, eMailLabel.Height + eMailLabel.Top + 10); // Set the position of the button on the form.

           //Button2 opcje
           button2.Text = "Zamknij"; // Set the text of button2 to "Cancel".
           button2.Location = new Point(button1.Left, button1.Height + button1.Top + 10); // Set the position of the button based on the location of button1.


           // Set the caption bar text of the form.   
           dodajKlientaForm.Text = "Formularz dodawania klienta";
           // Display a help button on the form.
           dodajKlientaForm.HelpButton = true;
           // Define the border style of the form to a dialog box.
           dodajKlientaForm.FormBorderStyle = FormBorderStyle.FixedDialog;
           // Set the MaximizeBox to false to remove the maximize box.
           dodajKlientaForm.MaximizeBox = false;
           // Set the MinimizeBox to false to remove the minimize box.
           dodajKlientaForm.MinimizeBox = false;
           // Set the accept button of the form to button1.
           dodajKlientaForm.AcceptButton = button1;
           // Set the cancel button of the form to button2.
           dodajKlientaForm.CancelButton = button2;
           // Set the start position of the form to the center of the screen.
           dodajKlientaForm.StartPosition = FormStartPosition.CenterScreen;

           // Add buttons to the form.
           dodajKlientaForm.Controls.Add(button1);
           dodajKlientaForm.Controls.Add(button2);

           //Dodaje labele do forma
           dodajKlientaForm.Controls.Add(imieLabel);
           dodajKlientaForm.Controls.Add(nazwiskoLabel);
           dodajKlientaForm.Controls.Add(peselLabel);
           dodajKlientaForm.Controls.Add(adresZameldowaniaLabel);
           dodajKlientaForm.Controls.Add(adresKorespondencyjnyLabel);
           dodajKlientaForm.Controls.Add(telefonLabel);
           dodajKlientaForm.Controls.Add(eMailLabel);
           
           //Dodaje texboxy do forma
           dodajKlientaForm.Controls.Add(imieTextBox);
           dodajKlientaForm.Controls.Add(nazwiskoTextBox);
           dodajKlientaForm.Controls.Add(peselTextBox);
           /*dodajKlientaForm.Controls.Add(adresZameldowaniaTextBox);
           dodajKlientaForm.Controls.Add(adresKorespondencyjnyTextBox);
           dodajKlientaForm.Controls.Add(telefonTextBox);
           dodajKlientaForm.Controls.Add(eMailTextBox);
           */

           // Display the form as a modal dialog box.

           dodajKlientaForm.ShowDialog();

          
           


       }


    }
}
