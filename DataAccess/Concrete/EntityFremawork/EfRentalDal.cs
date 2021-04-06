using Core.DataAccess;
using DataAccess.Apstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFremawork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, EfRentaCar>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join u in context.Users
                             on r.CustomerId equals u.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                Id= r.Id,
                                CarName = b.BrandName,
                                Customer = u.FirstName + " " + u.LastName,
                                RentDate = r.RentDate,
                                ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate)
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                bool isValidRentDate = context.Set<Rental>()
                    .Any(r => r.CarId == carId && (
                            (rentDate >= r.RentDate && rentDate <= r.ReturnDate) ||
                            (returnDate >= r.RentDate && returnDate <= r.ReturnDate) ||
                            (r.RentDate >= rentDate && r.RentDate <= returnDate)
                            )
                    );

                if ((!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }

                return false;
            }
        }
    } 
}
