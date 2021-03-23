using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            
                return new SuccessfulResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.CarInvalid);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessfulResult(Messages.CarDeleted);
        }
        public IResult Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessfulResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarUpdateInvalid);

        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            if (DateTime.Now.Hour == 23) return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

    }
}
