using MusicApp.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MusicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Saxophone : Page
    {
        public Saxophone()
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
                    Instrument = "Saxophone",
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
     

      
        private void Sax1_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s1.mp3");
             
        }

        private void Sax2_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s2.mp3");
        }

        private void Sax3_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s3.mp3");
        }

        private void Sax4_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s4.mp3");
        }

        private void Sax5_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s5.mp3");
        }

        private void Sax6_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s6.mp3");
        }

        private void Sax7_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s7.mp3");
        }

        private void Sax8_Click(object sender, RoutedEventArgs e)
        {
            WaitForTwoSeconds("ms-appx:///Assets/Sounds/Saxophone/s8.mp3");
        }

     

      
    }
}
                           