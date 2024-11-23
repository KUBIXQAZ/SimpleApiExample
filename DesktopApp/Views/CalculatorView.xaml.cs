// Importujemy wymagane przestrzenie nazw
using System.Net.Http; // Przestrzeń nazw do obsługi żądań HTTP
using System.Windows; // Przestrzeń nazw do obsługi funkcji aplikacji WPF
using System.Windows.Controls; // Przestrzeń nazw do obsługi elementów interfejsu użytkownika w WPF

namespace DesktopApp.Views
{
    // Klasa widoku kalkulatora, dziedzicząca po UserControl
    public partial class CalculatorView : UserControl
    {
        private HttpClient client; // Klient HTTP, używany do komunikacji z serwerem API

        // Konstruktor klasy CalculatorView
        public CalculatorView()
        {
            InitializeComponent(); // Inicjalizujemy elementy wizualne kontrolki

            client = GetHttpClient(); // Tworzymy instancję klienta HTTP
        }

        // Metoda tworzy i konfiguruje klienta HTTP
        private HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7099/Operations/"); // Ustawiamy adres bazowy API

            return client; // Zwracamy skonfigurowaną instancję klienta HTTP
        }

        // Obsługa zdarzenia kliknięcia przycisku dodawania wartości
        private async void AddValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text; // Pobieramy wartość pierwszego argumentu z pola tekstowego
                string b = SecondValue.Text; // Pobieramy wartość drugiego argumentu z pola tekstowego

                string url = $"add/{a}/{b}"; // Tworzymy adres URL dla operacji dodawania
                var answer = await client.GetAsync(url); // Wykonujemy żądanie GET do serwera API

                if (answer.IsSuccessStatusCode) // Sprawdzamy, czy żądanie zakończyło się sukcesem
                {
                    OperationTextBlock.Text = "+"; // Wyświetlamy symbol operacji w odpowiednim polu

                    string result = await answer.Content.ReadAsStringAsync(); // Odczytujemy odpowiedź jako tekst
                    AnswerTextBlock.Text = result; // Wyświetlamy wynik w polu odpowiedzi
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Wyświetlamy komunikat o błędzie, jeśli wystąpi wyjątek
            }
        }

        // Obsługa zdarzenia kliknięcia przycisku odejmowania wartości
        private async void SubtractValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text; // Pobieramy wartość pierwszego argumentu
                string b = SecondValue.Text; // Pobieramy wartość drugiego argumentu

                string url = $"subtract/{a}/{b}"; // Tworzymy adres URL dla operacji odejmowania
                var answer = await client.GetAsync(url); // Wysyłamy żądanie GET do serwera API

                if (answer.IsSuccessStatusCode) // Sprawdzamy, czy odpowiedź serwera jest poprawna
                {
                    OperationTextBlock.Text = "-"; // Wyświetlamy symbol operacji odejmowania

                    string result = await answer.Content.ReadAsStringAsync(); // Odczytujemy odpowiedź jako tekst
                    AnswerTextBlock.Text = result; // Wyświetlamy wynik w odpowiednim polu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Obsługujemy błędy
            }
        }

        // Obsługa zdarzenia kliknięcia przycisku mnożenia wartości
        private async void MuitiplyValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text; // Pobieramy wartość pierwszego argumentu
                string b = SecondValue.Text; // Pobieramy wartość drugiego argumentu

                string url = $"multiply/{a}/{b}"; // Tworzymy adres URL dla operacji mnożenia
                var answer = await client.GetAsync(url); // Wysyłamy żądanie GET do serwera API

                if (answer.IsSuccessStatusCode) // Sprawdzamy, czy operacja się powiodła
                {
                    OperationTextBlock.Text = "*"; // Wyświetlamy symbol operacji mnożenia

                    string result = await answer.Content.ReadAsStringAsync(); // Odczytujemy wynik jako tekst
                    AnswerTextBlock.Text = result; // Wyświetlamy wynik w odpowiednim polu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Wyświetlamy komunikat w przypadku błędu
            }
        }

        // Obsługa zdarzenia kliknięcia przycisku dzielenia wartości
        private async void DivideValuesButton(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = FirstValue.Text; // Pobieramy wartość pierwszego argumentu
                string b = SecondValue.Text; // Pobieramy wartość drugiego argumentu

                string url = $"divide/{a}/{b}"; // Tworzymy adres URL dla operacji dzielenia
                var answer = await client.GetAsync(url); // Wykonujemy żądanie GET do serwera API

                if (answer.IsSuccessStatusCode) // Sprawdzamy, czy żądanie zakończyło się sukcesem
                {
                    OperationTextBlock.Text = "/"; // Wyświetlamy symbol operacji dzielenia

                    string result = await answer.Content.ReadAsStringAsync(); // Odczytujemy wynik jako tekst
                    AnswerTextBlock.Text = result; // Wyświetlamy wynik w odpowiednim polu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // Obsługa błędów - wyświetlenie komunikatu
            }
        }
    }
}