// Importujemy wymagane przestrzenie nazw
using DesktopApp.Views; // Przestrzeń nazw zawierająca widoki aplikacji
using System.Windows; // Przestrzeń nazw do obsługi elementów WPF

namespace DesktopApp
{
    // Klasa reprezentująca główne okno aplikacji
    public partial class MainWindow : Window
    {
        // Konstruktor głównego okna
        public MainWindow()
        {
            InitializeComponent(); // Inicjalizujemy elementy wizualne okna

            LoadLoginView(); // Wczytujemy widok logowania jako widok startowy aplikacji
        }

        // Metoda ładuje widok logowania do głównej ramki okna
        private void LoadLoginView()
        {
            LoginView view = new LoginView(this); // Tworzymy instancję widoku logowania, przekazując referencję do bieżącego okna
            MainFrame.Content = view; // Ustawiamy widok logowania jako zawartość głównej ramki w oknie
        }
    }
}