using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarSellController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
