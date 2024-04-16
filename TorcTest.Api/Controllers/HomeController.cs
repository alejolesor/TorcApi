using Microsoft.AspNetCore.Mvc;
using TorcTest.Application.UseCases;

namespace TorcTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly TestIn _testInterface;
        public HomeController(TestIn testIn)
        {
            _testInterface = testIn;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var message = _testInterface.TestString();

            return Ok(message);
        }
    }
}
