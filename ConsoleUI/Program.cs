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
            //CarDetailsTest();

            //RentalTest();

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

            userManager.Add(new User { FirstName = "Engin", LastName = "Demiroğ", Email = "Engindemiroğ06@gmail.com", Password = "217645" });
            userManager.Add(new User { FirstName = "Mustafa Murat", LastName = "Coşkun", Email = "Mustafacoşkun34@gmail.com", Password = "923121" });
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetAll();

            foreach (var rental in result.Data)
            {
                Console.WriteLine("{0} - {1} - {2}", rental.CarId, rental.CustomerId, rental.RentDate);
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
                    Console.WriteLine("{0} - {1} - {2}", carDetail.CarName.Trim(), carDetail.BrandName.Trim(), carDetail.ColorName.Trim());
                    Console.WriteLine("--------------");
                    Console.WriteLine(result.Message);
                }

            }
        }
    }
}
