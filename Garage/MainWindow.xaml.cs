using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Garage
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
         //   InitialiserDateParution();
        }

       /* private void InitialiserDateParution()
        {

            for (int i = DateTime.Now.Year; i > 2019; i++)
            {
                cbbAnnee.Items.Add(i);
            };
        }*/


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {       
            Voiture maVoiture = new Voiture();
            maVoiture.AjouterVoiture(txtImmatriculation.Text, txtCouleur.Text, txtMarque.Text, txtVitesse.Text );
            

           /* if(voitureResult > 0)
            {

                MessageBox.Show("Bien Ajouté !");
                txtCategorie.Text = "";
                txtCouleur.Text = "";
                txtImmatriculation.Text = "";
                txtVitesse.Text = "";              
            }*/
            sqlConnect con = new sqlConnect();//instantiate a new object 'Con' from the class Sqlconnect.cs
            con.conOpen();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM Voiture ";
            command.Connection = con.Con;
            SqlDataReader dataReader = command.ExecuteReader();
            MessageBox.Show("Reader executé");

            while (dataReader.Read())
            {
                string voitureChaine = "code Immatriculation :"+(string)dataReader["codeImmatriculation"] + "| Couleur :  " + (string)dataReader["couleur"] + "| Marque :  " + (string)dataReader["marque"]+ " | Vitesse : " + (string)dataReader["vitesse"];
                listViewVoiture.Items.Add(voitureChaine);
            }
            con.conClose();
        }

        private void btnImportImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                imgSource.Source = new BitmapImage
                    (new Uri(ofd.FileName));
                imgSource.Stretch = Stretch.Fill;
            }

        }

        /*private void sldNbreVoiture_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblMarque.Content = (int)sldNbreVoiture.Value;      
        }*/
    }
}
