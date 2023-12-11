using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails();
        List<CarDetailsDto> GetCarDetailsByBrandId(int brandId);
        List<CarDetailsDto> GetCarDetailsByPriceRange(decimal minPrice, decimal maxPrice);

        List<CarDetailsDto> GetFilteredCarDetails(int? brandId, int? colorId, int? fuelId, int? gearId, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear);
    }
}
