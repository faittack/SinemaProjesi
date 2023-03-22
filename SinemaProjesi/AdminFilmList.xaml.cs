using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdminFilmList.xaml
    /// </summary>
    public partial class AdminFilmList : UserControl
    {
        public AdminFilmList()
        {
            InitializeComponent();
        }

      

        private void FilmEkle_Clk(object sender, RoutedEventArgs e)
        {
            FilmAdTxt.Text = "";       
            FilmEkle addMovie = new FilmEkle();
            addMovie.Show();
      
        }
        private void TabloListele(object sender, RoutedEventArgs e)
        {
            TabloDoldur.GridDoldur(Sinema_Listesi, "CinemaList");
            FilmAdTxt.IsEnabled = false;

        }      

        private void Btn_SelectedIndex(object sender, MouseButtonEventArgs e)
        {
            object item = Sinema_Listesi.SelectedItem;
            string Filmad = (Sinema_Listesi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            FilmAdTxt.Text = Filmad;
        }

        private void RemoveBtnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FilmAdTxt.Text))

            {
                MessageBox.Show("Lütfen bir film seçiniz!");

            }
          
            else
            {
                string selected = FilmAdTxt.Text;
                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5CTLLTC;Initial Catalog=Sinema_arsivDatabase;Integrated Security=True");
                SqlCommand komut = new SqlCommand("Delete From CinemaList Where FilmAdi =@pFilm", baglanti);
                baglanti.Open();
                komut.Parameters.AddWithValue("@pFilm", Convert.ToString(selected));
                komut.ExecuteNonQuery();
                komut.Parameters.Clear();
                baglanti.Close();

                MessageBox.Show("Film silinmiştir.");

                TabloDoldur.GridDoldur(Sinema_Listesi, "CinemaList");

                FilmAdTxt.Text = "";
            }
        }

        private void EditBtnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FilmAdTxt.Text))

            {
                MessageBox.Show("Lütfen bir film seçiniz!");

            }

            else
            {

                AdminFilmUpdate filmUpdate = new AdminFilmUpdate();
                            
                filmUpdate.Show();
                object item = Sinema_Listesi.SelectedItem;
                string Filmad = (Sinema_Listesi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                filmUpdate.FilmAdi_Txt.Text = Filmad;       
                
                string Filmad1 = (Sinema_Listesi.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                 filmUpdate.FilmYili_Txt.Text= Filmad1;
                
                string Filmad2 = (Sinema_Listesi.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                filmUpdate.FilmYon_Txt.Text = Filmad2;
                
                string Filmad3 = (Sinema_Listesi.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                filmUpdate.FilmTuru_CmdBx.Text = Filmad3;
               
                string Filmad4 = (Sinema_Listesi.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                filmUpdate.FilmIMDB_CmdBx.Text = Filmad4;


               
            }
          
        }

    }
}
