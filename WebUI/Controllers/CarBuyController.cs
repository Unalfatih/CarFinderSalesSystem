using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarBuyController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly IColorService _colorService;
        private readonly IFuelService _fuelService;
        private readonly IGearService _gearService;

        public CarBuyController(ICarService carService , IBrandService brandService , IColorService colorService , IFuelService fuelService , IGearService gearService)
        {
            _carService = carService;
            _brandService = brandService;
            _colorService = colorService;
            _fuelService = fuelService;
            _gearService = gearService;
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

        [HttpPost]
        public IDataResult<List<Brand>> GetBrands()
        {
            var brands = _brandService.GetAll();
            if (brands.Success)
            {
                return new SuccessDataResult<List<Brand>>(brands.Data);
            }
            return new ErrorDataResult<List<Brand>>("Brand Data Error!");
        }

        [HttpPost]
        public IDataResult<List<Color>> GetColors()
        {
            var colors = _colorService.GetAll();
            if (colors.Success)
            {
                return new SuccessDataResult<List<Color>>(colors.Data);
            }
            return new ErrorDataResult<List<Color>>("Color Data Error!");
        }

        [HttpPost]
        public IDataResult<List<Fuel>> GetFuels()
        {
            var fuels = _fuelService.GetAll();
            if (fuels.Success)
            {
                return new SuccessDataResult<List<Fuel>>(fuels.Data);
            }
            return new ErrorDataResult<List<Fuel>>("Fuel Data Error!");
        }

        [HttpPost]
        public IDataResult<List<Gear>> GetGears()
        {
            var gears = _gearService.GetAll();
            if (gears.Success)
            {
                return new SuccessDataResult<List<Gear>>(gears.Data);
            }
            return new ErrorDataResult<List<Gear>>("Gear Data Error!");
        }

        [HttpPost]
        public List<CarDetailsDto> GetFilteredCarDetails(int? brandId, int? colorId, int? fuelId, int? gearId, decimal? minPrice, decimal? maxPrice, int? minKm, int? maxKm, int? minYear, int? maxYear)
        {
            var cars = _carService.GetFilteredCarDetails(brandId, colorId, fuelId, gearId, minPrice, maxPrice, minKm, maxKm, minYear, maxYear).Data;
            return cars;

            //if (cars.Success)
            //{
            //    return new SuccessDataResult<List<CarDetailsDto>>(cars.Data);
            //}
            //return new ErrorDataResult<List<CarDetailsDto>>("Car Filtered Error!");
        }

        [HttpPost]
        public List<CarDetailsDto> CarDetailById(int Id)
        {
            var cars = _carService.GetCarDetailsById(Id).Data;
            return cars;
        }
    }
}
