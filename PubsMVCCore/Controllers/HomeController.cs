using Microsoft.AspNetCore.Mvc;

namespace PubsMVCCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
