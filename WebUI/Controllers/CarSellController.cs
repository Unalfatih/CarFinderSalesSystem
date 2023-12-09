using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CarSellController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IColorService _colorService;

        public CarSellController(IBrandService brandService, IColorService colorService)
        {
            _brandService = brandService;
            _colorService = colorService;
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
            return new ErrorDataResult<List<Brand>>("Data Error!");
        }

        [HttpPost]
        public IDataResult<List<Color>> GetColors()
        {
            var colors = _colorService.GetAll();
            if (colors.Success)
            {
                return new SuccessDataResult<List<Color>>(colors.Data);
            }
            return new ErrorDataResult<List<Color>>("Data Error!");
        }
    }
}
