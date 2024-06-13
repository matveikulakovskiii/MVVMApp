using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            // Создание и отображение меню
            string action = await DisplayActionSheet("Menu", "Cancel", null, "Training", "food", "Calculator");

            // Обработка выбора пункта меню
            switch (action)
            {
                case "Training":
                    await Navigation.PushAsync(new ExercisesPage()); // Переход на страницу тренировок
                    break;
                case "food":
                    await Navigation.PushAsync(new FoodPage()); // Переход на страницу пищи
                    break;
                case "Calculator":
                    await Navigation.PushAsync(new CalculatorPage()); // Переход на страницу калькулятора
                    break;
                default:
                    break;
            }
        }
    }
}
