using Microsoft.Maui.Controls;

namespace MVVMApp.Views
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HeightEntry.Text) || string.IsNullOrWhiteSpace(WeightEntry.Text))
            {
                DisplayAlert("Error", "Please enter both height and weight.", "OK");
                return;
            }

            if (!double.TryParse(HeightEntry.Text, out double height) || !double.TryParse(WeightEntry.Text, out double weight))
            {
                DisplayAlert("Error", "Invalid input. Please enter numeric values.", "OK");
                return;
            }

            // Calculate BMI
            double bmi = CalculateBMI(height, weight);

            // Interpret BMI category
            string bmiCategory = InterpretBMI(bmi);

            // Display result
            ResultLabel.Text = $"Your BMI: {bmi:F2}\nBMI Category: {bmiCategory}";
        }

        private double CalculateBMI(double heightCm, double weightKg)
        {
            // Convert height from cm to meters
            double heightM = heightCm / 100;

            // Calculate BMI
            double bmi = weightKg / (heightM * heightM);
            return bmi;
        }

        private string InterpretBMI(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight";
            else if (bmi < 25)
                return "Normal weight";
            else if (bmi < 30)
                return "Overweight";
            else
                return "Obesity";
        }
    }
}
