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
    /// Interaction logic for FilmEkle.xaml
    /// </summary>
    public partial class FilmEkle : Window
    {
        public FilmEkle()
        {
            InitializeComponent();
        }

        YoneticiSayfa gk = (YoneticiSayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);


        private void Geri(object sender, RoutedEventArgs e)
        {
            this.Close();
            gk.IsEnabled = true;
            gk.Opacity = 1;

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddBtnClk(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FilmAdi_Txt.Text) && String.IsNullOrEmpty(FilmYili_Txt.Text) && String.IsNullOrEmpty(FilmYon_Txt.Text))

            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!!");

            }

            else
            {


                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand commandRegister = new SqlCommand("INSERT INTO CinemaList(FilmAdi, FilmYili, FilmYonetmen,FilmTur,FilmİMDB) values (@film,@yil,@Yonetmen,@tur,@imdb)", baglanti);
                baglanti.Open();
                commandRegister.Parameters.AddWithValue("@film", FilmAdi_Txt.Text);
                commandRegister.Parameters.AddWithValue("@yil", FilmYili_Txt.Text);
                commandRegister.Parameters.AddWithValue("@Yonetmen", FilmYon_Txt.Text);
                commandRegister.Parameters.AddWithValue("@tur", FilmTuru_CmdBx.SelectionBoxItem.ToString());
                commandRegister.Parameters.AddWithValue("@imdb", int.Parse(FilmIMDB_CmdBx.SelectionBoxItem.ToString()));
                commandRegister.ExecuteNonQuery();
                commandRegister.Parameters.Clear();

                baglanti.Close();

                MessageBox.Show("Film Eklenmiştir.");



            }
        }
    }
}
