using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MusicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       public static MainPage Current
        {
            get; set;
        }
        public MainPage()
        {
            this.InitializeComponent();
            Current = this;
            Loaded += MainPage_Loaded;
            this.NavigationCacheMode = NavigationCacheMode.Required;
            HardwareButtons.BackPressed += (ss, ee) =>
            {
                if (MainFrame.CanGoBack)
                    MainFrame.GoBack();
           
                ee.Handled = true;
            };
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainFrame.BackStack.Count == 0)
                MainFrame.Navigate(typeof(BlankPage));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {  while (MainFrame.CanGoBack)
                MainFrame.GoBack();
           
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            while (MainFrame.CanGoBack)
                MainFrame.GoBack();
            MainFrame.Navigate(typeof(Page1));
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            if (BKmediaElement.CurrentState == Windows.UI.Xaml.Media.MediaElementState.Playing)
                BKmediaElement.Pause();
            else

                BKmediaElement.Play();
        }

        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            while (MainFrame.CanGoBack)
                MainFrame.GoBack();
            MainFrame.Navigate(typeof(UserProfile));
        }
    }
}
