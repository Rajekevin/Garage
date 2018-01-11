using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Garage
{
   public class Voiture
    {
        // Donnée membre 
        string codeImmatriculation;
        string couleur;
        string vitesse;

        // Méthodes de la classe
        public void AjouterVoiture(string codeImmatriculation, string couleurVoiture, string marqueVoiture, string vitesseVoiture)
        {
            sqlConnect con = new sqlConnect();//instantiate a new object 'Con' from the class Sqlconnect.cs
            con.conOpen();

            if (con != null)
            {
                //Ajout de nouveau Voiture
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Voiture VALUES ( @codeImmatriculation , @couleurVoiture,@marqueVoiture,   @vitesseVoiture)";
                  
                cmd.Connection = con.Con;
                cmd.Parameters.AddWithValue("@codeImmatriculation", codeImmatriculation);
                cmd.Parameters.AddWithValue("@couleurVoiture", couleurVoiture);
                cmd.Parameters.AddWithValue("@marqueVoiture", marqueVoiture);
                cmd.Parameters.AddWithValue("@vitesseVoiture", vitesseVoiture);

                MessageBox.Show("Reader executé");

                int result = cmd.ExecuteNonQuery();

                // Check Error
                if (result < 0)
                {
                    MessageBox.Show("Error insertion à la base");
                }
               
                con.conClose();              
            }
        }
   }
 }
