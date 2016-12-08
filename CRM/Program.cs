using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CRM
{
    public static class Program
    {
        //dane logowania uzytkownika 
        public static string userId = "0";
        public static string userLastLogin;
        public static string userName;
        public static string ostatnio;
        public static string[] ostatnioTablica = new string[] { };
        public static bool zalogowano = false;        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Uruchom forma do logowania
            Application.Run(new Logowanie());

            //Jeśli poprawne dane do logowania -> uruchom głównego forma
            if (Program.zalogowano == true)            
                Application.Run(new Form1()); 
        }

       public static void Logowanie(string log, string haslo)
        {
            MySqlCommand cmd = new MySqlCommand("select id,name,lastlogin,lasteditedclient from users where login = @log and password = @haslo;", SqlConnectionClass.myConnection);
                cmd.Parameters.AddWithValue("@log", log);
                cmd.Parameters.AddWithValue("@haslo", haslo);

            try
                { 
                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)                
                    SqlConnectionClass.myConnection.Open();     
           
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    userId = rdr[0].ToString();                      
                    userName = rdr[1].ToString();
                    userLastLogin = rdr[2].ToString();
                    ostatnio = rdr[3].ToString();
                }
                rdr.Close();
                
                // Jeśli udało się zalogować, zmienia date ostatniego logowania użytkownika na teraz
                if (userId != "0")
                {
                    MySqlCommand cmd1 = new MySqlCommand("Update users set lastlogin = now() + INTERVAL 8 HOUR where id = @userId;", SqlConnectionClass.myConnection);
                    cmd1.Parameters.AddWithValue("@userId", userId);
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    zalogowano = true;
                    rdr1.Close();
                }
                else
                    MessageBox.Show("Zły login/hasło!");
            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }  
           //wrzuca w tablice ostatnich klientow
            char delimiter = '-';
            ostatnioTablica = ostatnio.Split(delimiter);
            
        }
    }
}
