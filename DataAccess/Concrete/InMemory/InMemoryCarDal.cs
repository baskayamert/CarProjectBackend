using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carList;

        public InMemoryCarDal()
        {
            _carList = new List<Car> {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "BMW", ModelYear = "2010" },
                new Car{Id = 2, BrandId = 3, ColorId = 1, DailyPrice = 800, Description = "Mercedes", ModelYear = "2020" },
                new Car{Id = 3, BrandId = 4, ColorId = 1, DailyPrice = 250, Description = "Tofaş", ModelYear = "2008" },
                new Car{Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 200, Description = "Şahin", ModelYear = "2003" },
                new Car{Id = 5, BrandId = 5, ColorId = 1, DailyPrice = 150, Description = "Kartal", ModelYear = "2002" }
            };
        }
        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _carList.SingleOrDefault(c => c.Id == car.Id);
            _carList.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _carList;
        }

        public Car GetById(int id)
        {
            return _carList.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _carList.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
