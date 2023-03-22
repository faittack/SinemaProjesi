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
    /// Interaction logic for AdminKullaniciList.xaml
    /// </summary>
    public partial class AdminKullaniciList : UserControl
    {
        public AdminKullaniciList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TabloDoldur.GridDoldur(Kullanici_Listesi, "UserS Where Tip='User'");       
        }

        private void RemoveBtnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(KullaniciAdTxt.Text))

            {
                MessageBox.Show("Lütfen bir kişi seçiniz!");

            }

            else
            {
                string selected = KullaniciAdTxt.Text;
                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("Delete From UserS Where Kullanici_Adi =@pUser", baglanti);
                baglanti.Open();
                komut.Parameters.AddWithValue("@pUser", Convert.ToString(selected));
                komut.ExecuteNonQuery();
                komut.Parameters.Clear();
                baglanti.Close();

                MessageBox.Show("Kullanici silinmiştir.");

                TabloDoldur.GridDoldur(Kullanici_Listesi, "UserS Where Tip='User'");

                KullaniciAdTxt.Text = "";
            }
        }

        private void Kullanici_Listesi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = Kullanici_Listesi.SelectedItem;
            string UserAd = (Kullanici_Listesi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            KullaniciAdTxt.Text = UserAd;
        }
    }
}
