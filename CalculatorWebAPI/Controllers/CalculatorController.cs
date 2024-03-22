using CalculatorApi;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : Controller
    {
        private readonly ISimpleCalculator _calculator;
        private readonly IDiagnostics _diagnostics;

        public CalculatorController (ISimpleCalculator calculator, IDiagnostics diagnostics)
        {
            _calculator = calculator;
            _diagnostics = diagnostics;
        }

        [HttpGet("add")]
        public IActionResult Addition([FromQuery] int numOne, [FromQuery] int numTwo)
        {
            int result = _calculator.Add(numOne, numTwo);
            return Ok(result);
        }

        [HttpGet("subtract")]
        public IActionResult Substraction(int numOne, int numTwo)
        {
            int result = _calculator.Subtract(numOne, numTwo);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiplication(int numOne, int numTwo)
        {
            int result = _calculator.Multiply(numOne, numTwo);
            return Ok(result);
        }

        [HttpGet("divide")]
        public IActionResult Division(int numOne, int numTwo)
        {
            int result = _calculator.Divide(numOne, numTwo);
            return Ok(result);
        }

        /*
        public IActionResult Index()
        {
            return View();
        }*/
    }
}
