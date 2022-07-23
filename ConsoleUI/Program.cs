using Business.Concrete;
using Core.Entities.Concrete;
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
            //CarDetailsTest();

            RentalTest();

            //UserTest();s

            //CustomerTest();
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { UserId = 2, CompanyName = "SolidTeam" });
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(new User { FirstName = "Engin", LastName = "Demiroğ", Email = "Engindemiroğ06@gmail.com" });
            userManager.Add(new User { FirstName = "Mustafa Murat", LastName = "Coşkun", Email = "Mustafacoşkun34@gmail.com" });
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Update(new Rental { Id = 5, CarId = 3, CustomerId = 2, RentDate = new DateTime(2022, 06, 15), ReturnDate = DateTime.Now });

            var result = rentalManager.GetAll();

            foreach (var rental in result.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            foreach (var carDetail in result.Data)
            {
                if (result.Success)
                {
                    Console.WriteLine("{0} - {1} - {2}", carDetail.Description.Trim(), carDetail.BrandName.Trim(), carDetail.ColorName.Trim());
                    Console.WriteLine("--------------");
                    Console.WriteLine(result.Message);
                }

            }
        }
    }
}
