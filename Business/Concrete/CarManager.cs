using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessfulResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessfulResult(Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessfulResult(Messages.CarUpdated);
            }
            return new ErrorResult(Messages.CarUpdateInvalid);

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int id)
        {
            //if (DateTime.Now.Hour == 23) return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
           // if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
           // if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            //if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
           // if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().FindAll(c=>c.BrandId == brandId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            //if (DateTime.Now.Hour == 23) return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().FindAll(c=>c.ColorId == colorId));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }

        public IDataResult<CarDetailDto> GetCarDtoById(int carId)
        {
            //if (DateTime.Now.Hour == 23) return new ErrorDataResult<CarDetailDto>(Messages.MaintenanceTime);
            return new SuccessfulDataResult<CarDetailDto>(_carDal.GetCarDetails().Find(c => c.CarId == carId));
        }
    }
}
