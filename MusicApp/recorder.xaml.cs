using MusicApp.DataBase;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MusicApp
{
    
    public sealed partial class recorder : Page
    {
        public recorder()
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
                    Instrument = "Recorder",
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

      
       

        private void Rec1_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r1.mp3");
            
        }

        private void Rec2_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r2.mp3");
        }

        private void Rec3_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r3.mp3");
        }

        private void Rec4_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r4.mp3");
        }

        private void Rec5_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r5.mp3");
        }
         
        private void Rec6_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r6.mp3");
        }

        private void Rec7_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r7.mp3");
        }

        private void Rec8_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Recorder/r8.mp3");
        }

       

       
    }
} 
                  
                     