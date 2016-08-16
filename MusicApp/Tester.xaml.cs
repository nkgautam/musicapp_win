using MusicApp.DataBase;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MusicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Tester : Page
    {
        public Tester()
        {
            this.InitializeComponent();
            this.WaitForTwoSeconds();
        }
        private async void WaitForTwoSeconds()
        {
            await System.Threading.Tasks.Task.Delay(250);
        }
        string start = "";
        string end = "";
        RecordDatabaseHelper helper = new RecordDatabaseHelper();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            start = DateTime.Now.ToString();
        }
        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            end = DateTime.Now.ToString();
            if (!string.IsNullOrEmpty(App.EmailID))
            {
                await helper.AddRecord(new RecordTable()
                {
                    EmailID = App.EmailID,
                    Instrument = "Tambourine",
                    Start = start,
                    End = end
                });
            }

        }
        private async void WaitForTwoSeconds(String _url)
        {
            await System.Threading.Tasks.Task.Delay(250);
            myMediaElement.Source = new Uri(_url, UriKind.RelativeOrAbsolute);
            myMediaElement.Play();
            // await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(5));
            // do something after 2 seconds!
        }
     

        private void Test1_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r1.mp3");         
        }


        private void Test2_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r2.mp3");
        }

        private void Test3_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r3.mp3");
        }

        private void Test4_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r4.mp3");
        }

      
    }
}
 