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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCar>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos()
        {
            using (RentaCar context = new RentaCar())
            {
                var result = from p in context.Cars
                            join c in context.Brands
                            on p.BrandId equals c.Id
                            select new CarDetailDto
                            {
                                Id = p.Id,
                                Name = c.Name,
                                ModeLYear=p.ModeLYear
                            };
                return result.ToList();

            }
        }
    }
}
