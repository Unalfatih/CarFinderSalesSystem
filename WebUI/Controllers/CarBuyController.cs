using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarBuyController : Controller
    {
        private readonly ICarService _carService;

        public CarBuyController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<CarDetailsDto> GetCarDetails(int? brandFilter)
        {
            if (brandFilter.HasValue)
            {
                var cars = _carService.GetCarDetailsByBrandId(brandFilter.Value).Data;
                return cars;
            }
            else
            {

                var cars = _carService.GetCarDetails().Data;
                return cars;
            }

        }


    }
}
