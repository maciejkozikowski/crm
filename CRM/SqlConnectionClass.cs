using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;





namespace CRM
{


    class SqlConnectionClass
    {


        private static string myConnectionString = "server=mysql3.gear.host;uid=crmproject;" + "pwd=zaq1@WSX;database=crmproject;";
        public static MySqlConnection myConnection = new MySqlConnection(myConnectionString);


        public static void Foo(){
            try
        {
            if (myConnection.State == ConnectionState.Closed)
            {
               myConnection.Open();
            }
                
                
                //MessageBox.Show("Proszę czekać... \nTrwa łączenie z bazą MySql...");
                
                
           }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Nie można się połączyć z bazą danych!");
                        break;
                    case 1045:
                        MessageBox.Show("Zła nazwa/hasło użytkownika bazy danych");
                        break;
                }
            }

        }
        


    }
}
