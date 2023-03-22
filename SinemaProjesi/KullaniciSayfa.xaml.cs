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
using System.Windows.Controls.Primitives;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace SinemaProjesi
{
    /// <summary>
    /// Interaction logic for KullaniciSayfa.xaml
    /// </summary>



    public partial class KullaniciSayfa : Window
    {

        public static String KullaniciAdi;
        public static String KullaniciSifre;
       

        public KullaniciSayfa()
        {
            InitializeComponent();
        }

        private void Exit_Button(object sender, RoutedEventArgs e)

        {
            Environment.Exit(0);
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {

            SayfaCG.ucEkle(Content_icerik, new HomePage());


        }
        private void HomeButton_Enter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Home;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopUpTXT.Text = "Ana Sayfa";
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Sinema_List(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Sinema;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopUpTXT.Text = "Sinemalar";
        }

        private void Sinema_ListRemove(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }
        private void SinemaLike_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = SinemaLike;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopUpTXT.Text = "Beğenmeler";
        }

        private void SinemaLike_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void WatchLater_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = WatchLater;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopUpTXT.Text = "Sonra İzle";
        }

        private void WatchLater_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Options(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Ayarlar;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopUpTXT.Text = "Ayarlar";
        }

        private void Options_Remove(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SayfaCG.ucEkle(Content_icerik, new HomePage());
        }

        private void Sinema_Click(object sender, RoutedEventArgs e)
        {
         
            SayfaCG.ucEkle(Content_icerik, new KullaniciSinemaList());
        }

        private void Options(object sender, RoutedEventArgs e)
        {
            SayfaCG.ucEkle(Content_icerik, new KullanicilarOptions());

        }

        private void LikedBtn(object sender, RoutedEventArgs e)
        {
            SayfaCG.ucEkle(Content_icerik, new KullaniciLike());
        }

        private void WatchLater_Click(object sender, RoutedEventArgs e)
        {
            SayfaCG.ucEkle(Content_icerik, new KullaniciWatchLater());
        }

      
    }
}
