using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarProjectDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarProjectDBContext context = new CarProjectDBContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId

                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = color.Name,
                                 DailyPrice = c.DailyPrice,
                                 CarId = c.CarId,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 BrandId = b.BrandId,
                                 ColorId = color.ColorId,
                                 ImagePath = (from cimg in context.CarImages
                                              where cimg.CarId == c.CarId
                                              select cimg.ImagePath).SingleOrDefault()
                                
                             };
                return result.ToList();
            }
        }

    }
}
