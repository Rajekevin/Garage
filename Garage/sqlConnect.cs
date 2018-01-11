using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Garage
{
   public class sqlConnect
    {

        public SqlConnection Con { get; set; }//the object
        private string conString { get; set; }//the string to store your connection parameters

        public void conOpen()
        {
            conString = @"Data Source=DESKTOP-7H2T06B\SQLEXPRESS; 
                  Initial Catalog=garage;  
                  integrated security=True"; //the same as you post in your post
            Con = new SqlConnection(conString);
            try
            {
                Con.Open();//try to open the connection
                MessageBox.Show("Connexion réussie");
            }
            catch (Exception ex)
            {
                MessageBox.Show("YOUPLA ERREUR DE CONNEXION A LA BASE !!!!");
            }
        }
        public void conClose()
        {
            Con.Close(); //close the connection
        }
    }
}
