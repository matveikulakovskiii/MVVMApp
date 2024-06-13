using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            var user = App.Database.GetItems().FirstOrDefault(u => u.Email == email && u.Parol == password);
            if (user != null)
            {
                await Navigation.PushAsync(new WelcomePage());
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный Email или Пароль", "ОК");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
