using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 600, Description = "BMW", ModelYear = "2010" },
                new Car{CarId = 2, BrandId = 3, ColorId = 1, DailyPrice = 800, Description = "Mercedes", ModelYear = "2020" },
                new Car{CarId = 3, BrandId = 4, ColorId = 1, DailyPrice = 250, Description = "Tofaş", ModelYear = "2008" },
                new Car{CarId = 4, BrandId = 2, ColorId = 1, DailyPrice = 200, Description = "Şahin", ModelYear = "2003" },
                new Car{CarId = 5, BrandId = 5, ColorId = 1, DailyPrice = 150, Description = "Kartal", ModelYear = "2002" }
            };
        }
        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _carList.SingleOrDefault(c => c.CarId == car.CarId);
            _carList.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _carList;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _carList.SingleOrDefault(c => c.CarId == id);
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _carList.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
