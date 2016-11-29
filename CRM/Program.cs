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
        public static bool zalogowano = false;
        
        

        

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Logowanie());
            Application.Run(new Form1());
        }

       public static void Logowanie(string log, string haslo)
        {
            
            //2 server: 
            //MySqlConnection myConnection = new MySqlConnection();
            try
            {
                

                MySqlCommand cmd = new MySqlCommand("select id,name,lastlogin from users where login = '" + log + "' and password = '" + haslo + "';",
                   SqlConnectionClass.myConnection);

                //Czy jest polaczenie z baza ?
                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed) 
                {
                    SqlConnectionClass.myConnection.Open();
                }
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    userId = rdr[0].ToString();                      
                    userName = rdr[1].ToString();
                    userLastLogin = rdr[2].ToString(); 
                    
                    
                }
                rdr.Close();

                
                if (userId != "0")
                {
                    MySqlCommand cmd1 = new MySqlCommand("Update users set lastlogin = now() + INTERVAL 8 HOUR where id = '" + userId + "';",
                SqlConnectionClass.myConnection);
                    MySqlDataReader rdr1 = cmd1.ExecuteReader();
                    zalogowano = true;
                    MessageBox.Show("Zalogowano!");
                    
                }
                else
                {
                    MessageBox.Show("Zły login/hasło!");
                    

                }



            }

            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }










        }
    }
}
