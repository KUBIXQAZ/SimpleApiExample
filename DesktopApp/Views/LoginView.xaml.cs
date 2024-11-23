using System.Net.Http;
using System.Windows.Controls;

namespace DesktopApp.Views
{
    public partial class LoginView : UserControl
    {
        private MainWindow window;

        public LoginView(MainWindow window)
        {
            InitializeComponent();

            this.window = window;
        }

        private async void LoginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7099/");

                string url = $"login/{username}/{password}";
                var answer = await client.GetAsync(url);

                if (answer.IsSuccessStatusCode)
                {
                    CalculatorView view = new CalculatorView();
                    window.MainFrame.Content = view;
                } 
            }
        }
    }
}