using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebUI.Controllers
{
    public class CarSellController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IColorService _colorService;
        private readonly IFuelService _fuelService;
        private readonly IGearService _gearService;
        private readonly ICarService _carService;

        public CarSellController(IBrandService brandService, IColorService colorService, IFuelService fuelService, IGearService gearService, ICarService carService)
        {
            _brandService = brandService;
            _colorService = colorService;
            _fuelService = fuelService;
            _gearService = gearService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<Brand> GetAllBrands()
        {
            var categories = _brandService.GetAll().Data;
            return categories;
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
        public IResult AddCar(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return new SuccessResult("Car Added");
            }
            return new ErrorResult("Car Not Added");
        }
    }
}
