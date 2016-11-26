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

           //checkboxy
           CheckBox checkZgoda1 = new CheckBox();
           CheckBox checkZgoda2 = new CheckBox();
           CheckBox checkZgoda3 = new CheckBox();




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
           nazwiskoTextBox.Location = new Point(imieTextBox.Left, imieTextBox.Height + imieTextBox.Top + 2);
           //peselTextBox opcje
           peselTextBox.MaxLength = 11;
           peselTextBox.Location = new Point(nazwiskoTextBox.Left, nazwiskoTextBox.Height + nazwiskoTextBox.Top + 2);
           // adresZameldowaniaTextBox opcje
           adresZameldowaniaTextBox.Location = new Point(peselTextBox.Left, peselTextBox.Height + peselTextBox.Top + 2);
           //adresKorespondencyjnyTextBox opcje
           adresKorespondencyjnyTextBox.Location = new Point(adresZameldowaniaTextBox.Left, adresZameldowaniaTextBox.Height + adresZameldowaniaTextBox.Top + 2);
           //telefonTextBox opcje
           telefonTextBox.Location = new Point(adresKorespondencyjnyTextBox.Left, adresKorespondencyjnyTextBox.Height + adresKorespondencyjnyTextBox.Top + 2);
           //eMailTextBox opcje
           eMailTextBox.Location = new Point(telefonTextBox.Left, telefonTextBox.Height + telefonTextBox.Top + 2);


           // Create two buttons to use as the accept and cancel buttons.
           Button button1 = new Button();
           Button button2 = new Button();
           button1.Click += delegate
           {
               //MessageBox.Show("blablabla wykonuje sie niby, tak naprawde to nic sie nie dzieje bo trzeba dokonczyc kod, lololol"); //testowe okienoko
               //button2.PerformClick(); //ma sie zamykac okno po dodaniu klienta?
               //dodajKlientaForm.Close(); //nie wiem ktory lepszy
               string checkstring1 = "0";
               string checkstring2 = "0";
               string checkstring3 = "0";
               if (checkZgoda1.Checked)
                   checkstring1 = "1";
               if (checkZgoda2.Checked)
                   checkstring2 = "1";
               if (checkZgoda3.Checked)
                   checkstring3 = "1";

                try
            {
                string sql = "INSERT INTO klient(imie,nazwisko,pesel,adres_zam,adres_kor,telefon_kon,email,z_przetw,z_market,z_fak,data_utworzenia)" 
                    + " VALUES ('" 
                    + imieTextBox.Text.ToString() + "', '" 
                    + nazwiskoTextBox.Text.ToString() + "', '" 
                    + peselTextBox.Text.ToString() + "', '" 
                    + adresZameldowaniaTextBox.Text.ToString() + "', '" 
                    + adresKorespondencyjnyTextBox.Text.ToString() + "', '" 
                    + telefonTextBox.Text.ToString() + "', '"
                    + eMailTextBox.Text.ToString() + "', '"
                    + checkstring1 +"', '"
                    + checkstring2 +"', '"
                    + checkstring3 +"', "
                    + "CURDATE()"
                    + " );";
                
                  
                //cmd.CommandText = "SELECT count(*) from tbUser WHERE UserName = @username and password=@password";
                //command.Parameters.Add("@username", txtUserName.Text);
                //command.Parameters.Add("@password", txtPassword.Text);

                //treba to przepisac i zrobic tak jak wyzej, z tego co wyczytalem jak tak sie robi o mozna sie dobrac do komedy i hakowac -->>> https://www.owasp.org/index.php/SQL_Injection
                MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                
                MessageBox.Show("Dodano klienta do bazy!");
                button2.PerformClick();

            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }
                
                
           };
           
           //checkboxy opcje
           checkZgoda1.Location = new Point(eMailLabel.Left, eMailLabel.Height +  eMailLabel.Top + 10);
           checkZgoda1.Text = "Przetwarzanie";
           checkZgoda1.AutoSize = true;

           checkZgoda2.AutoSize = true;
           checkZgoda2.Location = new Point(checkZgoda1.Right, checkZgoda1.Top );
           checkZgoda2.Text = "Marketing";
           
           checkZgoda3.Location = new Point(checkZgoda2.Right -10 , checkZgoda2.Top);
           checkZgoda3.Text = "E-Faktura";
           checkZgoda3.AutoSize = true;

           //Button1 opcje
           button1.Text = "Dodaj"; // Set the text of button1 to "OK".
           button1.Location = new Point(eMailLabel.Left, eMailLabel.Height + eMailLabel.Top + 40); // Set the position of the button on the form.

           //Button2 opcje
           button2.Text = "Zamknij"; // Set the text of button2 to "Cancel".
           button2.Location = new Point(button1.Right + 10, button1.Top  ); // Set the position of the button based on the location of button1.


           // Set the caption bar text of the form.   
           dodajKlientaForm.Text = "Formularz dodawania klienta";
           // Display a help button on the form.
           dodajKlientaForm.HelpButton = false;
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
           dodajKlientaForm.Controls.Add(adresZameldowaniaTextBox);
           dodajKlientaForm.Controls.Add(adresKorespondencyjnyTextBox);
           dodajKlientaForm.Controls.Add(telefonTextBox);
           dodajKlientaForm.Controls.Add(eMailTextBox);
           
           // checkiboxy
           dodajKlientaForm.Controls.Add(checkZgoda1);
           dodajKlientaForm.Controls.Add(checkZgoda2);
           dodajKlientaForm.Controls.Add(checkZgoda3);

           // Display the form as a modal dialog box.

           dodajKlientaForm.ShowDialog();

          
           


       }


    }
}
