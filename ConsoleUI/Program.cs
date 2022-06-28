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

            var result = carManager.GetCarDetails();

            foreach (var carDetail in result.Data)
            {
                if (result.Success)
                {
                    Console.WriteLine("{0} - {1} - {2}", carDetail.CarName.Trim(), carDetail.BrandName.Trim(), carDetail.ColorName.Trim());
                    Console.WriteLine("--------------");
                    Console.WriteLine(result.Message);
                }

            }

        }
    }
}
