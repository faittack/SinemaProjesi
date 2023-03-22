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


namespace SinemaProjesi
{
    /// <summary>
    /// Interaction logic for YoneticiSayfa.xaml
    /// </summary>
    public partial class YoneticiSayfa : Window
    {
        public YoneticiSayfa()
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

        private void UserList_Button(object sender, RoutedEventArgs e)
        {
            SayfaCG.ucEkle(Content_icerik, new AdminKullaniciList());
        }

        private void SinemaList(object sender, RoutedEventArgs e)
        {
            SayfaCG.ucEkle(Content_icerik, new AdminFilmList());
        }


        private void HomeButton_Enter(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Home;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopUpTXT.Text = "Home";
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

        private void User_List(object sender, MouseEventArgs e)
        {
            popup_uc.PlacementTarget = Kullanıcılar;
            popup_uc.Placement = PlacementMode.Right;
            popup_uc.IsOpen = true;
            Header.PopUpTXT.Text = "Kullanıcılar";
        }

        private void User_ListRemove(object sender, MouseEventArgs e)
        {
            popup_uc.Visibility = Visibility.Collapsed;
            popup_uc.IsOpen = false;
        }
    

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SayfaCG.ucEkle(Content_icerik, new HomePage());
        }

       
    }
}
