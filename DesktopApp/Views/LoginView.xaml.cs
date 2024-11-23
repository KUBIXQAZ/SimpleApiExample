// Importujemy wymagane przestrzenie nazw
using System.Net.Http; // Przestrzeń nazw do obsługi żądań HTTP
using System.Windows.Controls; // Przestrzeń nazw do obsługi elementów interfejsu użytkownika w WPF

namespace DesktopApp.Views
{
    // Klasa widoku logowania, dziedzicząca po UserControl
    public partial class LoginView : UserControl
    {
        private MainWindow window; // Odniesienie do głównego okna aplikacji

        // Konstruktor widoku logowania
        public LoginView(MainWindow window)
        {
            InitializeComponent(); // Inicjalizujemy elementy wizualne kontrolki

            this.window = window; // Przypisujemy referencję do głównego okna
        }

        // Obsługa zdarzenia kliknięcia przycisku logowania
        private async void LoginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text; // Pobieramy nazwę użytkownika z pola tekstowego
            string password = PasswordBox.Password; // Pobieramy hasło z pola hasła

            using (HttpClient client = new HttpClient()) // Tworzymy tymczasowego klienta HTTP
            {
                client.BaseAddress = new Uri("https://localhost:7099/"); // Ustawiamy bazowy adres API

                string url = $"login/{username}/{password}"; // Tworzymy adres URL dla operacji logowania
                var answer = await client.GetAsync(url); // Wykonujemy żądanie GET do serwera API

                if (answer.IsSuccessStatusCode) // Sprawdzamy, czy logowanie zakończyło się sukcesem
                {
                    // Tworzymy widok kalkulatora i ustawiamy go jako zawartość głównej ramki w aplikacji
                    CalculatorView view = new CalculatorView();
                    window.MainFrame.Content = view; // Przełączamy widok na kalkulator
                }
                // Jeśli logowanie się nie powiedzie, brak dodatkowej obsługi
            }
        }
    }
}