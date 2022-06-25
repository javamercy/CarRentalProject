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

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { Name = "Honda" });
            //brandManager.Add(new Brand {  Name = "BMW" });
            //brandManager.Add(new Brand {  Name = "Audi" });
            //brandManager.Add(new Brand { Name = "Toyota" });
            //brandManager.Add(new Brand { Name = "Renault" });

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { Name = "Red" });
            //colorManager.Add(new Color { Name = "Yellow" });
            //colorManager.Add(new Color { Name = "Green" });
            //colorManager.Add(new Color { Name = "Blue" });
            //colorManager.Add(new Color { Name = "Black" });
            //colorManager.Add(new Color { Name = "White" });
            //colorManager.Add(new Color { Name = "Gray" });
            //colorManager.Add(new Color { Name = "Purple" });


            CarManager carManager = new CarManager(new EfCarDal());


            //carManager.Add(new Car { BrandId = 1003, ColorId = 1003, DailyPrice = 150, Description = "Honda Civic", ModelYear = 2010 });
            //carManager.Add(new Car { BrandId = 1004, ColorId = 1004, DailyPrice = 200, Description = "BMW i8", ModelYear = 2005 });
            //carManager.Add(new Car { BrandId = 1005, ColorId = 1004, DailyPrice = 300, Description = "Audi A3", ModelYear = 2012 });
            //carManager.Add(new Car { BrandId = 1006, ColorId = 1005, DailyPrice = 250, Description = "Toyota Corolla", ModelYear = 2008 });
            //carManager.Add(new Car { BrandId = 1007, ColorId = 1003, DailyPrice = 600, Description = "Renault Clio", ModelYear = 2017 });

            //foreach (var car in carManager.GetCarsByBrandId(1005))
            //{
            //    Console.WriteLine(car.Description); --> Audi A3
            //}


            //carManager.Add(new Car { BrandId = 1005, ColorId = 1006, DailyPrice = 375, Description = "", ModelYear = 2017 });
            carManager.Add(new Car { BrandId = 1005, ColorId = 1006, DailyPrice = 375, Description = "Audi RS", ModelYear = 2017 });

        }
    }
}
