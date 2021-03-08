using Core.DataAccess;
using DataAccess.Apstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFremawork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EfRentaCar>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors
                             on c.ColorId equals c1.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = c1.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName=c1.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModeLYear = c.ModeLYear,
                                 Description = c.Description,
                             };
                return result.ToList();

            }
        }
    }
}
