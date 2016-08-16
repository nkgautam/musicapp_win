using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MusicApp.DataBase;
namespace MusicApp
{
  
    public sealed partial class drum : Page
    {
        

        public drum()
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
                        Instrument= "Drum",
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

  

        private void Drum1_Click(object sender, RoutedEventArgs e)
        { 
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Drums/drum.mp3");
        
        }

        private void Drum2_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Drums/drumloud.mp3");
        }

       

     
    }
}
  