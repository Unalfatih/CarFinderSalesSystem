using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsById(int Id);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByPriceRange(decimal min, decimal max);
        IDataResult<List<CarDetailsDto>> GetFilteredCarDetails(int? brandId, int? colorId, int? fuelId, int? gearId, decimal? minPrice, decimal? maxPrice, int? minKm, int? maxKm, int? minYear, int? maxYear);

        IResult Add(Car car);
       
    }
}
