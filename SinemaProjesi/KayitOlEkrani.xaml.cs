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
using System.Windows.Shapes;

namespace SinemaProjesi
{
    /// <summary>
    /// Interaction logic for KayitOlEkrani.xaml
    /// </summary>
    public partial class KayitOlEkrani : Window
    {
        public KayitOlEkrani()
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

            SifreTekrarBx1.Text = SifreTekrarBx.Password;
            SifreTekrarBx.Visibility = Visibility.Collapsed;
            SifreTekrarBx1.Visibility = Visibility.Visible;
        }
        private void ŞifreyiGizle(object sender, RoutedEventArgs e)
        {
            SifreBx.Password = SifreBx1.Text;
            SifreBx1.Visibility = Visibility.Collapsed;
            SifreBx.Visibility = Visibility.Visible;

            SifreTekrarBx.Password = SifreTekrarBx1.Text;
            SifreTekrarBx1.Visibility = Visibility.Collapsed;
            SifreTekrarBx.Visibility = Visibility.Visible;
        }

        private void GirisEkrani(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void RergisterBTNClick(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(KayitKullaniciAdi.Text))

            {
                MessageBox.Show("Kullanıcı Adını Doldurunuz.");

            }
            else if (String.IsNullOrEmpty(SifreBx.Password) || String.IsNullOrEmpty(SifreBx1.Text) || String.IsNullOrEmpty(SifreTekrarBx.Password) || String.IsNullOrEmpty(SifreTekrarBx1.Text))
            {
                MessageBox.Show("Şifre Kutularını tam doldurduğunuzdan emin olunuz.");

            }
            else if (SifreBx.Password != SifreTekrarBx.Password || SifreBx1.Text != SifreTekrarBx1.Text)
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
            }
            else
            {

                bool Tmp = false;
                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("Select * From UserS Where Kullanici_Adi ='" + KayitKullaniciAdi.Text + "'" + " And Tip='User'", baglanti);
                baglanti.Open();
                SqlDataReader read;
                komut.Connection = baglanti;
                read = komut.ExecuteReader();

                if (read.Read() == true)
                {

                    Tmp = true;

                }
                baglanti.Close();

              
                if (Tmp)
                {
                    MessageBox.Show("Başka bir kullanıcı adı seçiniz.");
                }
                else
                {
                    SqlCommand commandRegister = new SqlCommand("INSERT INTO UserS(Kullanici_Adi, Sifre, Tip) values (@Kullanici,@Sifre,'User')", baglanti);

                    baglanti.Open();

                    commandRegister.Parameters.AddWithValue("@Kullanici", KayitKullaniciAdi.Text);
                    commandRegister.Parameters.AddWithValue("@Sifre", SifreBx.Password);
                    commandRegister.ExecuteNonQuery();
                    commandRegister.Parameters.Clear();
                    baglanti.Close();

                    MessageBox.Show("Kaydınız başarılı.");

                   

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();


                }
             


            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

