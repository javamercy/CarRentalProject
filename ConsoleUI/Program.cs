using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", carDetail.CarId, carDetail.CarName.Trim(), carDetail.BrandName.Trim(), carDetail.ColorName.Trim(), carDetail.DailyPrice);
            }

        }
    }
}
