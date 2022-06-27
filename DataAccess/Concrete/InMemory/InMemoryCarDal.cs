using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 150, Description = "Renault Clio", ModelYear = 2010},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 1500, Description = "Bugatti Chiron", ModelYear = 2018},
                new Car{Id = 3, BrandId = 3, ColorId = 2, DailyPrice = 750, Description = "Lamborghini Astana ", ModelYear = 2014},
                new Car{Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 500, Description = "Lamborghini Aventador", ModelYear = 2016},
                new Car{Id = 5, BrandId = 4, ColorId = 3, DailyPrice = 400, Description = "BMW i8", ModelYear = 2016},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public List<CarDetailDto> getCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
