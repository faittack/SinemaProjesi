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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SifreGoster(object sender, RoutedEventArgs e)
        {

            SifreBx1.Text = SifreBx.Password;
            SifreBx.Visibility = Visibility.Collapsed;
            SifreBx1.Visibility = Visibility.Visible;

        }

        private void ŞifreyiGizle(object sender, RoutedEventArgs e)
        {
            SifreBx.Password = SifreBx1.Text;
            SifreBx1.Visibility = Visibility.Collapsed;
            SifreBx.Visibility = Visibility.Visible;
        }

        private void KullaniciGiris(object sender, RoutedEventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select * From UserS Where Kullanici_Adi ='" + KullaniciTxt.Text + "'" + " And Tip='User'", baglanti);
            baglanti.Open();
            SqlDataReader read;
            komut.Connection = baglanti;
            read = komut.ExecuteReader();

            if (read.Read() == true && (!String.IsNullOrEmpty(SifreBx.Password) || !String.IsNullOrEmpty(SifreBx1.Text)))
            {
                if (SifreBx.Password == read["Sifre"].ToString() || SifreBx1.Text == read["Sifre"].ToString())
                {

                    
                    KullaniciSayfa kullaniciSayfa = new KullaniciSayfa();
                    kullaniciSayfa.Show();
                    this.Close();

                    KullaniciSayfa.KullaniciAdi = KullaniciTxt.Text;
                    KullaniciSayfa.KullaniciSifre = SifreBx.Password;

                }
                else
                {
                    MessageBox.Show("Şifrenizi Kontrol Ediniz");
                }
            }
            else
            {
                MessageBox.Show("Bilgilerinizi Kontrol Ediniz");
            }

            baglanti.Close();

        }





        private void KayitOl(object sender, RoutedEventArgs e)
        {
            KayitOlEkrani kayitOlEkrani = new KayitOlEkrani();
            kayitOlEkrani.Show();
            this.Close();
        }

        private void YoneticiGirisBtn(object sender, RoutedEventArgs e)
        {
            YoneticiGirisEkrani yoneticiGirisEkrani = new YoneticiGirisEkrani();
            yoneticiGirisEkrani.Show();
            this.Close();
        }
    }
}
