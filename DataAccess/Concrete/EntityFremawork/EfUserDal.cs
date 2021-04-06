using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Apstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFremawork
{
    public class EfUserDal : EfEntityRepositoryBase<User,EfRentaCar>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EfRentaCar())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
        public List<UserRentalsCarDto> GetRentalDetails(Expression<Func<UserRentalsCarDto, bool>> filter = null)
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars on rental.CarId equals car.CarId
                             join customer in context.Customers on rental.CustomerId equals customer.UserId
                             join user in context.Users on customer.UserId equals user.Id
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new UserRentalsCarDto()
                             {
                                 Id = rental.Id, 
                                 CarId = car.CarId,
                                 UserId = user.Id, 
                                 CarBrand = brand.BrandName,
                                 CarModel = car.ModeLYear,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 CarDescription = car.Description,
                                
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
