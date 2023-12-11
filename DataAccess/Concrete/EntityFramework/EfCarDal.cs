using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarFinderSalesSystemContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarFinderSalesSystemContext context = new CarFinderSalesSystemContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands on p.BrandId equals b.Id
                             join c in context.Colors on p.ColorId equals c.Id
                             join f in context.Fuels on p.FuelId equals f.Id
                             join g in context.Gears on p.GearId equals g.Id
                             join i in context.Images on p.Id equals i.CarId
                             select new CarDetailsDto
                             {
                                 Id = p.Id,
                                 ColorId = c.Id,
                                 BrandId = b.Id,
                                 FuelId = f.Id,
                                 GearId = g.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 FuelName = f.Name,
                                 GearName = g.Name,
                                 ModelYear = p.ModelYear,
                                 Price = p.Price,
                                 Description = p.Description,
                                 CarImage = i.Image1,

                             };
                return result.ToList();

            }
        }

        public List<CarDetailsDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarFinderSalesSystemContext context = new CarFinderSalesSystemContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors on p.ColorId equals c.Id
                             join f in context.Fuels on p.FuelId equals f.Id
                             join g in context.Gears on p.GearId equals g.Id
                             join i in context.Images on p.Id equals i.CarId
                             join b in context.Brands on p.BrandId equals b.Id
                             where b.Id == brandId
                             select new CarDetailsDto
                             {
                                 Id = p.Id,
                                 ColorId = c.Id,
                                 BrandId = b.Id,
                                 FuelId = f.Id,
                                 GearId = g.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 FuelName = f.Name,
                                 GearName = g.Name,
                                 ModelYear = p.ModelYear,
                                 Price = p.Price,
                                 Description = p.Description,
                                 CarImage = i.Image1,

                             };
                return result.ToList();

            }
        }

        public List<CarDetailsDto> GetCarDetailsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (CarFinderSalesSystemContext context = new CarFinderSalesSystemContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands on p.BrandId equals b.Id
                             join c in context.Colors on p.ColorId equals c.Id
                             join i in context.Images on p.Id equals i.CarId
                             where p.Price >= minPrice && p.Price <= maxPrice
                             select new CarDetailsDto
                             {
                                 Id = p.Id,
                                 ColorId = c.Id,
                                 BrandId = b.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 ModelYear = p.ModelYear,
                                 Price = p.Price,
                                 Description = p.Description,
                                 CarImage = i.Image1
                             };

                return result.ToList();
            }
        }

        public List<CarDetailsDto> GetFilteredCarDetails(int? brandId, int? colorId, int? fuelId, int? gearId, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            using (CarFinderSalesSystemContext context = new CarFinderSalesSystemContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands on p.BrandId equals b.Id
                             join c in context.Colors on p.ColorId equals c.Id
                             join f in context.Fuels on p.FuelId equals f.Id
                             join g in context.Gears on p.GearId equals g.Id
                             join i in context.Images on p.Id equals i.CarId
                             where
                                 (!brandId.HasValue || b.Id == brandId.Value) &&
                                 (!colorId.HasValue || c.Id == colorId.Value) &&
                                 (!fuelId.HasValue || f.Id == fuelId.Value) &&
                                 (!gearId.HasValue || g.Id == gearId.Value) &&
                                 (!minPrice.HasValue || p.Price >= minPrice.Value) &&
                                 (!maxPrice.HasValue || p.Price <= maxPrice.Value) &&
                                 (!minYear.HasValue || p.ModelYear >= minYear.Value) &&
                                 (!maxYear.HasValue || p.ModelYear <= maxYear.Value)

                             select new CarDetailsDto
                             {
                                 Id = p.Id,
                                 ColorId = c.Id,
                                 BrandId = b.Id,
                                 FuelId = f.Id,
                                 GearId = g.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 FuelName = f.Name,
                                 GearName = g.Name,
                                 ModelYear = p.ModelYear,
                                 Price = p.Price,
                                 Description = p.Description,
                                 CarImage = i.Image1
                             };

                return result.ToList();
            }
        }
    }

}

