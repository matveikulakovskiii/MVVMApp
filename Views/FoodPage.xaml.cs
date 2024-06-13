using Microsoft.Maui.Controls;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage : ContentPage
    {
        public FoodPage()
        {
            InitializeComponent();
        }

        private async void OnPreMeditationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreMeditationNutritionPagexaml());
        }

        private async void OnPostMeditationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PostMeditationNutritionPage());
        }
    }
}
