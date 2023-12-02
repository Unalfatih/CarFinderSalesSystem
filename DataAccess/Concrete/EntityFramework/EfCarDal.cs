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
                                 Image = p.Image,
                             };
                 return result.ToList();
                             
            }
        }

        public List<CarDetailsDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarFinderSalesSystemContext context = new CarFinderSalesSystemContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands on p.BrandId equals b.Id
                             join c in context.Colors on p.ColorId equals c.Id
                             where b.Id == brandId
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
                                 Image = p.Image,
                             };
                return result.ToList();

            }
        }


    }
}
