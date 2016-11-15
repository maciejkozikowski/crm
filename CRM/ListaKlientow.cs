using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web;

namespace CRM
{
    public class ListaKlientow
    {
        static DataGridView dgv1 = new DataGridView();

        public static void Form()
        {
            //int odleglosc = 25;
            // Create a new instance of the form.
            Form ListaKlientowForm = new Form();

            // Create two buttons to use as the accept and cancel buttons.
            Button button1 = new Button();
            Button button2 = new Button();
            Button button3 = new Button();

            dgv1.ReadOnly = true;
            button3.Text = "Tryb Edycji: OFF"; // 
            button3.AutoSize = true;

            button1.Location = new Point(dgv1.Left + 50, 420); // Set the position of the button on the form.
            button2.Location = new Point(button3.Right + 50, 420); // Set the position of the button on the form.
            button3.Location = new Point(button1.Right + 75, 420); // Set the position of the button on the form.
            //Button1 opcje
            
             button1.Hide();
             button1.Text = "Zaktualizuj bazę"; // .
             button2.Text = "Zamknij"; // 
            

            
           

            // Set the caption bar text of the form.   
            ListaKlientowForm.Text = "Lista klientów";
            // Display a help button on the form.
            ListaKlientowForm.HelpButton = false;
            // Define the border style of the form to a dialog box.
            ListaKlientowForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            ListaKlientowForm.MaximizeBox = true;
            // Set the MinimizeBox to false to remove the minimize box.
            ListaKlientowForm.MinimizeBox = false;
            // Set the accept button of the form to button1.
            ListaKlientowForm.AcceptButton = button1;
            // Set the cancel button of the form to button2.
            ListaKlientowForm.CancelButton = button2;
            // Set the start position of the form to the center of the screen.
            ListaKlientowForm.StartPosition = FormStartPosition.CenterScreen;

            // Add buttons to the form.
            ListaKlientowForm.Controls.Add(button1); //Aktualizuj
            ListaKlientowForm.Controls.Add(button2); //Zamknij
            ListaKlientowForm.Controls.Add(button3); //tryb edycji

            try
            {
                string sql = "select * from klient;";

                //MySqlCommand cmd = new MySqlCommand(sql, SqlConnectionClass.myConnection);
                //MySqlDataReader rdr = cmd.ExecuteReader();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, SqlConnectionClass.myConnection);
                DataSet DS = new DataSet();

                if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
                {
                    SqlConnectionClass.myConnection.Open();
                }

                adapter.Fill(DS);
                
                // nazwa datagridview -> dgv1
                dgv1.DataSource = DS.Tables[0];
                
                //dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);  // erory robi
                //dgv1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells); // to tez
                dgv1.Size = new Size(800, 400);
                
                ListaKlientowForm.Controls.Add(dgv1);

                
               /* dgv1.CellClick += delegate
                {
                    MessageBox.Show("row");

                };
                */

                
                button1.Click += delegate
                                {
                                    

                                    DataTable changes = ((DataTable)dgv1.DataSource).GetChanges();

                                    if (changes != null)
                                    {
                                        try
                                        {
                                            if (SqlConnectionClass.myConnection.State == ConnectionState.Closed)  //Jest połączony z bazą??
                                            {
                                                SqlConnectionClass.myConnection.Open();
                                            }


                                            MySqlCommandBuilder mcb = new MySqlCommandBuilder(adapter);
                                            adapter.UpdateCommand = mcb.GetUpdateCommand();
                                            adapter.Update(changes);
                                            ((DataTable)dgv1.DataSource).AcceptChanges();
                                            MessageBox.Show("okej");
                                        }
                                        catch (MySqlException ex)
                                        {
                                            MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
                                        }
                                        
                                    }


                                };

                button2.Click += delegate
                {
                    try
                    {


                        dgv1.DataSource = null;
                        
                    }
                    catch (DataException e)
                    {
                        // Process exception and return.
                        Console.WriteLine("Exception of type {0} occurred.",
                            e.GetType());
                    }


                };

                button3.Click += delegate
                {

                    if (dgv1.ReadOnly == false)
                    {
                        button3.Text = "Tryb Edycji: OFF"; // 
                        button1.Hide();
                        
                        dgv1.ReadOnly = true;
                        
                    }

                    else
                    {
                        button1.Show();
                        dgv1.ReadOnly = false;
                        button3.Text = "Tryb Edycji: ON"; //              
                                                  
                    }
                        


                };


                /*
                while (rdr.Read())
                {
                    MessageBox.Show(
                        rdr[0] + " -- " + rdr[1]
                        + " -- " + rdr[2]
                        + " -- " + rdr[3]
                        + " -- " + rdr[4]
                        + " -- " + rdr[5]
                        + " -- " + rdr[6]
                        + " -- " + rdr[7]



                        );
                }
                 
                */





                //rdr.Close();
                
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Błąd numer: " + ex.Number + " , " + ex.Message);
            }

            



            // Display the form as a modal dialog box.
            ListaKlientowForm.Size = new Size(800, 500);
            ListaKlientowForm.ShowDialog();

            
          

        }


        
            
       


        
    }

}
