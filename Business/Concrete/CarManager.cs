using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (CheckIfNameIsLongEnough(car.Description) && CheckIfPriceHigherThanZero(car.DailyPrice))
            {
                _carDal.Add(car);
                return new SuccessResult();
            }


            throw new Exception("Please check car details!");


        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.AllCarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarListedById);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.getCarDetails(),Messages.AllCarsListedWithDetails);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }


        private bool CheckIfNameIsLongEnough(string description)
        {
            return description.Length > 2;

        }
        private bool CheckIfPriceHigherThanZero(decimal dailyPrice)
        {
            return dailyPrice > 0;
        }

    }
}
