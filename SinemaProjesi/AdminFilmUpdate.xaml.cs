using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SinemaProjesi
{
    /// <summary>
    /// Interaction logic for AdminFilmUpdate.xaml
    /// </summary>
    public partial class AdminFilmUpdate : Window
    {
        static String FilmAdı;
        static String FilmYili;
        static String FilmYonetmen;
        static String FilmTur;
        static String FilmIMDB;

        public AdminFilmUpdate()
        {
            InitializeComponent();
        }

        YoneticiSayfa gk = (YoneticiSayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
      
        private void Geri(object sender, RoutedEventArgs e)
        {
            gk.IsEnabled = true;
            gk.Opacity = 1;
            this.Close();

        }
        

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UpdateBtnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FilmAdi_Txt.Text) && String.IsNullOrEmpty(FilmYili_Txt.Text) && String.IsNullOrEmpty(FilmYon_Txt.Text))

            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!!");

            }

            else
            {
                FilmAdı=FilmAdi_Txt.Text;

                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("UPDATE CinemaList SET FilmAdi=@pfilm, FilmYili=@pyil, FilmYonetmen=@pYonetmen, FilmTur=@ptur, FilmİMDB=@pimdb WHERE FilmAdi='" + FilmAdı +"'", baglanti);
              
                baglanti.Open();
               
                komut.Parameters.AddWithValue("@pfilm", FilmAdi_Txt.Text);
                komut.Parameters.AddWithValue("@pyil", int.Parse(FilmYili_Txt.Text));
                komut.Parameters.AddWithValue("@pYonetmen", FilmYon_Txt.Text);
                komut.Parameters.AddWithValue("@ptur", FilmTuru_CmdBx.SelectionBoxItem.ToString());
                komut.Parameters.AddWithValue("@pimdb", int.Parse(FilmIMDB_CmdBx.SelectionBoxItem.ToString()));
              
                komut.ExecuteNonQuery();

                komut.Dispose();
                baglanti.Close();
             

                MessageBox.Show("Film güncellenmiştir.");


            }
        }
        
    }

  
}

