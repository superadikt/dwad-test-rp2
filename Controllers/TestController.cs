using Microsoft.AspNetCore.Mvc;

namespace DwadTestRp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
