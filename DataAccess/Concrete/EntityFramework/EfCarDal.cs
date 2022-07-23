using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars

                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join color in context.Colors
                             on car.ColorId equals color.Id


                             select new CarDetailDto { CarId = car.Id, BrandId = brand.Id, BrandName = brand.Name, Description = car.Description, ColorId = color.Id, ColorName = color.Name, DailyPrice = car.DailyPrice, ImagePaths = (from images in context.CarImages where images.CarId == car.Id select images.ImagePath).ToList() };


                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }


    }
}
