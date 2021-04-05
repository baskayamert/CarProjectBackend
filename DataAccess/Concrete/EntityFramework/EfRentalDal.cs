using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarProjectDBContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarProjectDBContext context = new CarProjectDBContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers on r.CustomerId equals c.CustomerId
                             join u in context.Users on c.UserId equals u.UserId
                             join car in context.Cars on r.CarId equals car.CarId
                             join b in context.Brands on car.BrandId equals b.BrandId

                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 BrandName = b.Name,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
