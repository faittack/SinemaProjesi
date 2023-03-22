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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SinemaProjesi
{
    /// <summary>
    /// Interaction logic for KullaniciSinemaList.xaml
    /// </summary>
    public partial class KullaniciSinemaList : UserControl
    {
  
        public KullaniciSinemaList()
        {
            InitializeComponent();
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SearchBTN(object sender, RoutedEventArgs e)
        {        
            if (FilmTuru_CmdBx.SelectionBoxItem!=null && !String.IsNullOrEmpty(FilmYili_Txt.Text) && FilmImdb_CmdBx.SelectionBoxItem!= null)
            {
            string tmp = "CinemaList Where FilmTur='" + FilmTuru_CmdBx.SelectionBoxItem.ToString() + "' And FilmYili >=" + int.Parse(FilmYili_Txt.Text) + " And FilmİMDB >=" + int.Parse(FilmImdb_CmdBx.SelectionBoxItem.ToString())+"";

            TabloDoldur.GridDoldur(SıralamaList, tmp);
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olunuz!!");
            }


            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TabloDoldur.GridDoldur(SıralamaList, "CinemaList");
            FilmAdTxt.IsEnabled = false;
            FilmLikeBx.SelectedIndex = 0;

        }

        private void SıralamaList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = SıralamaList.SelectedItem;
            string Filmad = (SıralamaList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            FilmAdTxt.Text = Filmad;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(FilmAdTxt.Text))

            {
                MessageBox.Show("Lütfen bir film seçiniz!");
            }
            else if (FilmLikeBx.SelectionBoxItem == null )
            {      
                MessageBox.Show("Lutfen puan seçiniz!!");
            }
            else
            {

                bool Tmp = false;
                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("Select * From CinemaListLike Where FilmAdi ='" + FilmAdTxt.Text + "' And Begenen='"+KullaniciSayfa.KullaniciAdi+"'", baglanti);
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
                    MessageBox.Show("Bu film zaten eklenmiştir.");
                }
                else 
                {
                
                    SqlCommand commandRegister = new SqlCommand("INSERT INTO CinemaListLike(FilmAdi, FilmYili, FilmYonetmen,FilmTur,FilmİMDB,Puan,Begenen) values (@filmad,@yil,@yonetmen,@tur,@imdb,@puan,@begen)", baglanti);

                    baglanti.Open();

                    object item = SıralamaList.SelectedItem;

                    string Filmad = (SıralamaList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad1 = (SıralamaList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad2 = (SıralamaList.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad3 = (SıralamaList.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad4 = (SıralamaList.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;


                    commandRegister.Parameters.AddWithValue("@filmad", Filmad);
                    commandRegister.Parameters.AddWithValue("@yil", int.Parse(Filmad1));
                    commandRegister.Parameters.AddWithValue("@yonetmen", Filmad2);
                    commandRegister.Parameters.AddWithValue("@tur", Filmad3);
                    commandRegister.Parameters.AddWithValue("@imdb", int.Parse(Filmad4));
                    commandRegister.Parameters.AddWithValue("@puan", int.Parse(FilmLikeBx.SelectionBoxItem.ToString()));
                    commandRegister.Parameters.AddWithValue("@begen", KullaniciSayfa.KullaniciAdi);

                    commandRegister.ExecuteNonQuery();
                    commandRegister.Parameters.Clear();
                    baglanti.Close();

                    MessageBox.Show("Kaydınız başarılı.");



                }
               

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FilmAdTxt.Text))

            {
                MessageBox.Show("Lütfen bir film seçiniz!");
            }         
            else
            {

                bool Tmp = false;
                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("Select * From CinemaWatchLater1 Where FilmAdi ='" + FilmAdTxt.Text + "' And Kullanici='" + KullaniciSayfa.KullaniciAdi + "'", baglanti);
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
                    MessageBox.Show("Bu film zaten eklenmiştir.");
                }
                else
                {

                    SqlCommand commandRegister = new SqlCommand("INSERT INTO CinemaWatchLater1(FilmAdi, FilmYili, FilmYonetmen,FilmTur,FilmİMDB,Kullanici) values (@filmad,@yil,@yonetmen,@tur,@imdb,@kullanici)", baglanti);

                    baglanti.Open();

                    object item = SıralamaList.SelectedItem;

                    string Filmad = (SıralamaList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad1 = (SıralamaList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad2 = (SıralamaList.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad3 = (SıralamaList.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;

                    string Filmad4 = (SıralamaList.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;


                    commandRegister.Parameters.AddWithValue("@filmad", Filmad);
                    commandRegister.Parameters.AddWithValue("@yil", int.Parse(Filmad1));
                    commandRegister.Parameters.AddWithValue("@yonetmen", Filmad2);
                    commandRegister.Parameters.AddWithValue("@tur", Filmad3);
                    commandRegister.Parameters.AddWithValue("@imdb", int.Parse(Filmad4));                   
                    commandRegister.Parameters.AddWithValue("@kullanici", KullaniciSayfa.KullaniciAdi);

                    commandRegister.ExecuteNonQuery();
                    commandRegister.Parameters.Clear();
                    baglanti.Close();

                    MessageBox.Show("Kaydınız başarılı.");



                }


            }
        }
    }
}
