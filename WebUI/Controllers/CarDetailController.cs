using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
