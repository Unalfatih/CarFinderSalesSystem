using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarDetailController : Controller
    {
        private readonly ICarService _carService;

        public CarDetailController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<CarDetailsDto> CarDetailById(int Id)
        {
            var cars = _carService.GetCarDetailsById(Id).Data;
            return cars;
        }
    }
}
