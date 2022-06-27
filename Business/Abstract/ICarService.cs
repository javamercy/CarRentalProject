﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);

        Car GetById(int id);

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        List<Car> GetAll();

        List<CarDetailDto> GetCarDetails();

    }
}
