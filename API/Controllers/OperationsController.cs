using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : Controller
    {
        [HttpGet("add/{first}/{second}")]
        public IActionResult Add(string first, string second)
        {
            try
            {
                float a = float.Parse(first);
                float b = float.Parse(second);

                return Ok(a + b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest("Internal server error!");
            }
        }

        [HttpGet("subtract/{first}/{second}")]
        public IActionResult Subtract(string first, string second)
        {
            try
            {
                float a = float.Parse(first);
                float b = float.Parse(second);

                return Ok(a - b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest("Internal server error!");
            }
        }

        [HttpGet("multiply/{first}/{second}")]
        public IActionResult Multiply(string first, string second)
        {
            try
            {
                float a = float.Parse(first);
                float b = float.Parse(second);

                return Ok(a * b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest("Internal server error!");
            }
        }

        [HttpGet("devide/{first}/{second}")]
        public IActionResult Devide(string first, string second)
        {
            try
            {
                float a = float.Parse(first);
                float b = float.Parse(second);

                if (b == 0) return BadRequest("You can't devide by 0.");

                return Ok(a / b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest("Internal server error!");
            }
        }
    }
}