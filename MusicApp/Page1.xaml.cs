using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;


namespace MusicApp
{

    public sealed partial class Page1 : Page
    {
        public Page1()
        {
            this.InitializeComponent();
        }

     
        private void btnName_Tapped(object sender, TappedRoutedEventArgs e)
        {
           MainPage.Current.MainFrame.Navigate(typeof(drum));
        }

        private void btnsaxo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.Current.MainFrame.Navigate(typeof(Saxophone));
        }
        private void btnrecorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.Current.MainFrame.Navigate(typeof(recorder));
        }
       

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.Current.MainFrame.Navigate(typeof(Tester));
        }





       
    }
}
