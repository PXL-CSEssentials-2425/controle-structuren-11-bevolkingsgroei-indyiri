using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H3Oef11Bevolkingsgroei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            countryTextBox.Clear();
            growthPercentageTextBox.Clear();
            currentPopulationTextBox.Clear();
            resultTextBox.Clear();
            countryTextBox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            string country = countryTextBox.Text;
            double currentPopulation;
            double growthPercentage;
            string inputCurrentPopulation = currentPopulationTextBox.Text;
            string inputGrowthPercentage = growthPercentageTextBox.Text;   

            bool isInputCurrentPopulationValid = double.TryParse(inputCurrentPopulation, out currentPopulation);
            bool isInputGrowthPercentageValid = double.TryParse(inputGrowthPercentage, out growthPercentage);

            double newPopulation = 2.00 * currentPopulation;
            double yearsToDouble = 0;

            if (isInputCurrentPopulationValid && isInputGrowthPercentageValid && growthPercentage != 0)
            {
                while (currentPopulation <= newPopulation)
                {
                    currentPopulation *= ((growthPercentage / 100.00) + 1.00);
                    yearsToDouble++;
                }
                resultTextBox.Text = $"Verdubbeling bevolking van {country} na {yearsToDouble} jaar.\n\rNieuwe bevolkingsaantal op dat moment: {newPopulation}";
            }           
            else if ((!isInputCurrentPopulationValid || !isInputGrowthPercentageValid) && growthPercentage != 0)
            {
                resultTextBox.Text = "Geef een correcte huidige bevolking en groeipercentage in";
            }
            else
            {
                resultTextBox.Text = "Groeipercentage mag niet 0 zijn: zonder groeipercentage nooit een verdubbeling van de bevolking";
            }
        }
    }
}