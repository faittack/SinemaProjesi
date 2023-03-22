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

namespace SinemaProjesi
{
    /// <summary>
    /// Interaction logic for KullaniciLike.xaml
    /// </summary>
    public partial class KullaniciLike : UserControl
    {
        public KullaniciLike()
        {
            InitializeComponent();
        }
       
           
     

        private void RemoveBtnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FilmAdiTxt.Text))

            {
                MessageBox.Show("Lütfen bir film seçiniz!");

            }

            else
            {
                string begenen = KullaniciSayfa.KullaniciAdi;
                string selected = FilmAdiTxt.Text;

                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("Delete From CinemaListLike Where Begenen =@pbegen And FilmAdi=@pfilmadi", baglanti);
                baglanti.Open();
                komut.Parameters.AddWithValue("@pbegen", begenen);
                komut.Parameters.AddWithValue("@pfilmadi", Convert.ToString(selected));
                komut.ExecuteNonQuery();
                komut.Parameters.Clear();
                baglanti.Close();

                MessageBox.Show("Film silinmiştir.");

                TabloDoldur.GridDoldur(BegenenListesi, "CinemaListLike Where Begenen='" + KullaniciSayfa.KullaniciAdi + "'");

                FilmAdiTxt.Text = "";
            }
        }

        private void Kullanici_Listesi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = BegenenListesi.SelectedItem;
            string UserAd = (BegenenListesi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            FilmAdiTxt.Text = UserAd;
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            FilmAdiTxt.IsEnabled = false;
            TabloDoldur.GridDoldur(BegenenListesi, "CinemaListLike Where Begenen='" + KullaniciSayfa.KullaniciAdi + "'");
        }
    }
}
