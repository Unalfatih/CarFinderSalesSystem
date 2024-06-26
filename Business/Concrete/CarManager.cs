﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "Arabalar Listelendi");
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByPriceRange(decimal min, decimal max)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetailsByPriceRange(min,max));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetailsByBrandId(brandId));
        }

        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult("Car Added");
        }

        public IDataResult<List<CarDetailsDto>> GetFilteredCarDetails(int? brandId, int? colorId, int? fuelId, int? gearId, decimal? minPrice, decimal? maxPrice, int? minKm, int? maxKm, int? minYear, int? maxYear)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetFilteredCarDetails(brandId, colorId, fuelId, gearId, minPrice, maxPrice,minKm,maxKm, minYear, maxYear));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetailsById(int Id)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetailsById(Id));
        }
    }
}
