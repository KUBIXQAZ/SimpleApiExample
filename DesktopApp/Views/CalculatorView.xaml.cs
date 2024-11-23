using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace DesktopApp.Views
{
    public partial class CalculatorView : UserControl
    {
        private HttpClient client;

        public CalculatorView()
        {
            InitializeComponent();

            client = GetHttpClient();
        }

        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7099/Operations/");

            return client;
        }

        private async void AddValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text;
                string b = SecondValue.Text;

                string url = $"add/{a}/{b}";
                var answer = await client.GetAsync(url);

                if (answer.IsSuccessStatusCode)
                {
                    OperationTextBlock.Text = "+";

                    string result = answer.Content.ReadAsStringAsync().Result;
                    AnswerTextBlock.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void SubtractValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text;
                string b = SecondValue.Text;

                string url = $"subtract/{a}/{b}";
                var answer = await client.GetAsync(url);

                if (answer.IsSuccessStatusCode)
                {
                    OperationTextBlock.Text = "-";

                    string result = answer.Content.ReadAsStringAsync().Result;
                    AnswerTextBlock.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void MuitiplyValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text;
                string b = SecondValue.Text;

                string url = $"multiply/{a}/{b}";
                var answer = await client.GetAsync(url);

                if (answer.IsSuccessStatusCode)
                {
                    OperationTextBlock.Text = "*";

                    string result = answer.Content.ReadAsStringAsync().Result;
                    AnswerTextBlock.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void DivideValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text;
                string b = SecondValue.Text;

                string url = $"divide/{a}/{b}";
                var answer = await client.GetAsync(url);
                
                if (answer.IsSuccessStatusCode)
                {
                    OperationTextBlock.Text = "/";

                    string result = answer.Content.ReadAsStringAsync().Result;
                    AnswerTextBlock.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
