using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.SqlClient;


namespace SinemaProjesi
{

    
    /// <summary>
    /// Interaction logic for YoneticiGirisEkrani.xaml
    /// </summary>
    public partial class YoneticiGirisEkrani : Window
    {
        public YoneticiGirisEkrani()
        {
            InitializeComponent();
        }

        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SifreGoster(object sender, RoutedEventArgs e)
        {

            YoneticiSifre1.Text = YoneticiSifre.Password;
            YoneticiSifre.Visibility = Visibility.Collapsed;
            YoneticiSifre1.Visibility = Visibility.Visible;

        }


        private void ŞifreyiGizle(object sender, RoutedEventArgs e)
        {
            YoneticiSifre.Password = YoneticiSifre1.Text;
            YoneticiSifre1.Visibility = Visibility.Collapsed;
            YoneticiSifre.Visibility = Visibility.Visible;
        }

        private void YoneticiEkranGiris(object sender, RoutedEventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select * From UserS Where Kullanici_Adi ='" + YoneticiGiris.Text +"'" + " And Tip='Admin'" , baglanti);
            baglanti.Open();
            SqlDataReader read;
            komut.Connection = baglanti;
            read = komut.ExecuteReader();

            if (read.Read() == true && (!String.IsNullOrEmpty(YoneticiSifre.Password) || !String.IsNullOrEmpty(YoneticiSifre1.Text)))
            {
                if (YoneticiSifre.Password == read["Sifre"].ToString() || YoneticiSifre1.Text== read["Sifre"].ToString())
                {

                   
                    YoneticiSayfa yoneticiEkran = new YoneticiSayfa();
                    yoneticiEkran.Show();
                    this.Close();

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



        private void KayıtOlBtn(object sender, RoutedEventArgs e)
        {
            KayitOlEkrani kayitol = new KayitOlEkrani();
            kayitol.Show();
            this.Close();
        }
    }
}
