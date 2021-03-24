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
            //Test();

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //AddColor(colorManager);
            //ColorTest(colorManager);

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //AddBrand(brandManager);
            //BrandTest(brandManager);

            CarManager carManager = new CarManager(new EfCarDal());
            //AddCar(carManager);
            //CarTest(carManager);

            //CarDetailTest(carManager);

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            User user1 = new User() { Id = 1, Email = "someone@hotmail.com", FirstName = "Some", LastName = "One", Password = "123" };
            Customer customer1 = new Customer() {Id = 1, UserId = 1, CompanyName ="X company"};
            userManager.Add(user1);
            customerManager.Add(customer1);

            User user2 = new User() { Id = 2, Email = "someone2@hotmail.com", FirstName = "Some", LastName = "One2", Password = "321" };
            Customer customer2 = new Customer() {Id = 2, UserId = 2, CompanyName = "Y company" };
            customerManager.Add(customer2);

            Rental rental1 = new Rental() { RentalId = 1, CarId = 1, CustomerId = 1, RentDate = "24.03.2021", ReturnDate = null };
            Console.WriteLine(rentalManager.Add(rental1).Message);
        }

        private static void CarDetailTest(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var carDetail in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3}", carDetail.CarName, carDetail.BrandName, carDetail.ColorName, carDetail.DailyPrice);

                }
            }
            else Console.WriteLine(result.Message);
        }

        private static void CarTest(CarManager carManager)
        {
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else Console.WriteLine(result.Message);

            var result2 = carManager.GetById(2);
            if (result2.Success)
            {
                Console.WriteLine(result2.Data.Description);
            }
            else Console.WriteLine(result2.Message);
           
            var result3 = carManager.Update(new Car() { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 275, Description = "Bad car", ModelYear = "1998" });
            var result4 = carManager.Delete(new Car() { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 275, Description = "Bad car", ModelYear = "1998" });

            Console.WriteLine(result3.Message);
            Console.WriteLine(result4.Message);
        }

        private static void AddCar(CarManager carManager)
        {
            var result = carManager.Add(new Car() { Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 400, Description = "Good car", ModelYear = "2010" });
            var result2 = carManager.Add(new Car() { Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 500, Description = "Super car", ModelYear = "2000" });
            var result3 = carManager.Add(new Car() { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 275, Description = "Old car", ModelYear = "1998" });

            Console.WriteLine(result.Message);
            Console.WriteLine(result2.Message);
            Console.WriteLine(result3.Message);
        }

        private static void BrandTest(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine(brandManager.GetById(2).Name);
            brandManager.Update(new Brand() { Id = 3, Name = "Şahin" });
            brandManager.Delete(new Brand() { Id = 3, Name = "Şahin" });
        }

        private static void AddBrand(BrandManager brandManager)
        {
            brandManager.Add(new Brand() { Id = 1, Name = "BMW" });
            brandManager.Add(new Brand() { Id = 2, Name = "Mercedes" });
            brandManager.Add(new Brand() { Id = 3, Name = "Tesla" });
        }

        private static void ColorTest(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine(colorManager.GetById(2).Name);

            colorManager.Update(new Color() { Id = 5, Name = "Red" });

            colorManager.Delete(new Color() { Id = 3, Name = "Red" });
        }

        private static void AddColor(ColorManager colorManager)
        {
            colorManager.Add(new Color() { Id = 1, Name = "Brown" });
            colorManager.Add(new Color() { Id = 2, Name = "Black" });
            colorManager.Add(new Color() { Id = 3, Name = "Blue" });
        }

        private static void Test()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car() { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "BMW", ModelYear = "2010" });
            carManager.Add(new Car { Id = 2, BrandId = 3, ColorId = 1, DailyPrice = 800, Description = "Mercedes", ModelYear = "2020" });
            carManager.Add(new Car { Id = 3, BrandId = 4, ColorId = 1, DailyPrice = 250, Description = "Tofaş", ModelYear = "2008" });
            carManager.Add(new Car { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 200, Description = "Şahin", ModelYear = "2003" });
            carManager.Add(new Car { Id = 5, BrandId = 5, ColorId = 1, DailyPrice = 150, Description = "Kartal", ModelYear = "2002" });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
