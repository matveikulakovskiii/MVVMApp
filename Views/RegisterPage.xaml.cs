using MVVMApp.Models;
using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var user = new Friend { Name = name, Email = email, Parol = password };
                App.Database.SaveItem(user);
                await Navigation.PopAsync(); // Возвращаемся на страницу входа
            }
            else
            {
                await DisplayAlert("Ошибка", "Заполните все поля", "ОК");
            }
        }
    }
}
