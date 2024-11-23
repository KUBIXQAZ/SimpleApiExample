using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace API.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        // Łańcuch połączenia z bazą danych
        private string connectionString;

        // Konstruktor kontrolera, pobiera łańcuch połączenia z pliku konfiguracji
        public LoginController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        // Endpoint obsługujący logowanie na podstawie nazwy użytkownika i hasła
        [HttpGet("Login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                // Tworzenie połączenia z bazą danych
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // Otwarcie połączenia

                    // Zapytanie SQL do sprawdzania użytkownika w bazie
                    string sql = "SELECT * FROM users WHERE Username = @Username && Password = @Password;";

                    // Tworzenie komendy SQL z parametrami
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // Przekazanie wartości parametrów do zapytania
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Wykonanie zapytania i odczyt wyników
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Sprawdzanie czy znaleziono pasującego użytkownika
                            if (reader.HasRows)
                            {
                                return Ok(true); // Użytkownik istnieje - zwraca wartość true
                            }
                            else
                            {
                                return NotFound(false); // Użytkownik nie istnieje - zwraca wartość false
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędu i logowanie informacji o błędzie w konsoli
                Console.WriteLine($"Error: {ex.Message}");
                // Zwrócenie błędu 400 z informacją o problemie
                return BadRequest("Internal server error!");
            }
        }
    }
}