using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MVVMApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisesPage : ContentPage
    {
        public ExercisesPage()
        {
            InitializeComponent();
        }

        private async void OnBeginnerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BeginnerExercisesPage()); // Переход на страницу для новичков
        }

        private async void OnProfessionalClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfessionalExercisesPage()); // Переход на страницу для профессионалов
        }
    }
}
