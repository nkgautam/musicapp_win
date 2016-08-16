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
using MusicApp.DataBase;
using Windows.UI.Popups;
using MusicApp.ViewModel;

namespace MusicApp
{
  
    public sealed partial class UserProfile : Page
    {
        public UserProfileViewModel ViewModel
        {
            get
            {
                return this.DataContext as UserProfileViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        public UserProfile()
        {
            this.InitializeComponent();
            ViewModel = new UserProfileViewModel();
            helper = new UserDatabaseHelper();
            btnLogin.Click += BtnLogin_Click;
            btnRegister.Click += BtnRegister_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            App.EmailID = "";
            LayoutLogin.Visibility = Visibility.Visible;
            layoutData.Visibility = Visibility.Collapsed;
        }

        private async void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            bool exist = await helper.CheckAvailable(txtEmail.Text.Trim());
            if (exist == true)
            {
                var dialog = new MessageDialog("This email aready registered");
                await dialog.ShowAsync();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && !string.IsNullOrEmpty(txtPass.Password.Trim()))
                {
                    helper.AddUser(new UserTable()
                    {
                        EmailID = txtEmail.Text.Trim(),
                        Password = txtPass.Password.Trim()
                    });
                    var dialog = new MessageDialog("Register complete!");
                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog = new MessageDialog("Missing email or password!");
                    await dialog.ShowAsync();
                }
            }
        }

        UserDatabaseHelper helper;
        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool exist = await helper.CheckLogin(txtEmail.Text.Trim(), txtPass.Password.Trim());
            if (exist == false)
            {
                var dialog = new MessageDialog("Wrong email or pass");
                await dialog.ShowAsync();
            }
            else
            {
                App.EmailID = txtEmail.Text.Trim();
                TitleUser.Text = "User : "+App.EmailID;
                LayoutLogin.Visibility = Visibility.Collapsed;
                layoutData.Visibility = Visibility.Visible;
                ViewModel.LoadData(App.EmailID);
             
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (string.IsNullOrEmpty(App.EmailID))
            {
                LayoutLogin.Visibility = Visibility.Visible;
                layoutData.Visibility = Visibility.Collapsed;
            }
            else
            {
            
                TitleUser.Text = "User : "+ App.EmailID;
                LayoutLogin.Visibility = Visibility.Collapsed;
                layoutData.Visibility = Visibility.Visible;
                ViewModel.LoadData(App.EmailID);
            }
        }
    }
}
