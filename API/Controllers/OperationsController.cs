﻿using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : Controller
    {
        // Endpoint do dodawania dwóch liczb
        [HttpGet("Add/{first}/{second}")]
        public IActionResult Add(string first, string second)
        {
            try
            {
                // Konwersja parametrów wejściowych na typ float
                float a = float.Parse(first);
                float b = float.Parse(second);

                // Zwrócenie wyniku dodawania
                return Ok(a + b);
            }
            catch (Exception ex)
            {
                // Obsługa błędu i logowanie w konsoli
                Console.WriteLine($"Error: {ex.Message}");
                // Zwrócenie błędu 400
                return BadRequest("Internal server error!");
            }
        }

        // Endpoint do odejmowania dwóch liczb
        [HttpGet("Subtract/{first}/{second}")]
        public IActionResult Subtract(string first, string second)
        {
            try
            {
                // Konwersja parametrów wejściowych na typ float
                float a = float.Parse(first);
                float b = float.Parse(second);

                // Zwrócenie wyniku odejmowania
                return Ok(a - b);
            }
            catch (Exception ex)
            {
                // Obsługa błędu i logowanie w konsoli
                Console.WriteLine($"Error: {ex.Message}");
                // Zwrócenie błędu 400
                return BadRequest("Internal server error!");
            }
        }

        // Endpoint do mnożenia dwóch liczb
        [HttpGet("Multiply/{first}/{second}")]
        public IActionResult Multiply(string first, string second)
        {
            try
            {
                // Konwersja parametrów wejściowych na typ float
                float a = float.Parse(first);
                float b = float.Parse(second);

                // Zwrócenie wyniku mnożenia
                return Ok(a * b);
            }
            catch (Exception ex)
            {
                // Obsługa błędu i logowanie w konsoli
                Console.WriteLine($"Error: {ex.Message}");
                // Zwrócenie błędu 400
                return BadRequest("Internal server error!");
            }
        }

        // Endpoint do dzielenia dwóch liczb
        [HttpGet("Divide/{first}/{second}")]
        public IActionResult Divide(string first, string second)
        {
            try
            {
                // Konwersja parametrów wejściowych na typ float
                float a = float.Parse(first);
                float b = float.Parse(second);

                // Sprawdzenie czy dzielenie przez 0
                if (b == 0) return BadRequest("You can't divide by 0.");

                // Zwrócenie wyniku dzielenia
                return Ok(a / b);
            }
            catch (Exception ex)
            {
                // Obsługa błędu i logowanie w konsoli
                Console.WriteLine($"Error: {ex.Message}");
                // Zwrócenie błędu 400
                return BadRequest("Internal server error!");
            }
        }
    }
}