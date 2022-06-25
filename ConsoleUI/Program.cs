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

            //BrandManager brandManager = new BrandManager(new EfBrandDal());


            //ColorManager colorManager = new ColorManager(new EfColorDal());


            CarManager carManager = new CarManager(new EfCarDal());


            Console.WriteLine(carManager.GetCarById(1).Description); // Renault Megane

            foreach (var car in carManager.GetCarsByBrandId(1)) 
            {
                Console.WriteLine(car.Description); // BMW 320i
            }

            foreach (var car in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine(car.Description); // Audi A3
            }

        }
    }
}
