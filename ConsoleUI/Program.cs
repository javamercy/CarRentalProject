using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("--------------------------------------------------------");

            //carManager.Add(new Car { Id = 6, BrandId = 4, ColorId = 2, DailyPrice = 200, Description = "Honda Civic", ModelYear = 2005 });
            //carManager.Delete(new Car { Id = 2 });
            //carManager.Update(new Car { Id = 6, BrandId = 4, ColorId = 2, DailyPrice = 200, Description = "Honda", ModelYear = 2005 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }


        }
    }
}
