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

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}",carDetail.CarName,carDetail.BrandName,carDetail.ColorName,carDetail.DailyPrice);

            }
        }

        private static void CarTest(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine(carManager.GetById(2).Description);
            carManager.Update(new Car() { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 275, Description = "Bad car", ModelYear = "1998" });
            carManager.Delete(new Car() { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 275, Description = "Bad car", ModelYear = "1998" });
        }

        private static void AddCar(CarManager carManager)
        {
            carManager.Add(new Car() { Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 400, Description = "Good car", ModelYear = "2010" });
            carManager.Add(new Car() { Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 500, Description = "Super car", ModelYear = "2000" });
            carManager.Add(new Car() { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 275, Description = "Old car", ModelYear = "1998" });
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

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
