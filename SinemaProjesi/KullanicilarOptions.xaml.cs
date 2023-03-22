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
    /// Interaction logic for KullanicilarOptions.xaml
    /// </summary>
    public partial class KullanicilarOptions : UserControl
    {
        public KullanicilarOptions()
        {
            InitializeComponent();
        }
        
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(KullaniciGiris.Text) && string.IsNullOrEmpty(KullaniciGiris1.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!!");
            }else if (!KullaniciGiris.Text.Equals(KullaniciGiris1.Text))
            {
                MessageBox.Show("Şifreler uyuşmuyor!!");
            }
            else
            {
                String KullaniciAdi = KullaniciSayfa.KullaniciAdi;

                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("UPDATE UserS SET Sifre=@psifre WHERE Kullanici_Adi='" + KullaniciAdi + "' And Tip = 'User' ", baglanti);

                baglanti.Open();

                komut.Parameters.AddWithValue("@psifre", KullaniciGiris.Text);

                komut.ExecuteNonQuery();

                komut.Dispose();
                baglanti.Close();


                MessageBox.Show("Şifre güncellenmiştir.");

                KullaniciGiris.Text = null;
                KullaniciGiris1.Text = null;



            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Name.IsEnabled = false;
            Name.Text = KullaniciSayfa.KullaniciAdi;
        }
    }
}
