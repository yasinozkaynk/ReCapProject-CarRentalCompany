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
        public List<CarDetailDto> GetCar()
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
                                 colorId = c1.ColorId,
                                 ColorName = c1.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 brandId = b.BrandId,
                                 CarName = b.BrandName,
                                 MinFindexScore = c.MinFindexScore,
                                 ImagePath = context.CarsImages.Where(w => w.CarId == c.CarId).FirstOrDefault().ImagePath,

                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarBrandDetailDtos(int brandId)
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                var result = from c in context.Cars
                             join b in context.Brands.Where(w => w.BrandId == brandId)
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors
                             on c.ColorId equals c1.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 colorId=c1.ColorId,
                                 ColorName=c1.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 brandId=b.BrandId,
                                 CarName=b.BrandName,
                                 MinFindexScore = c.MinFindexScore,
                                 ImagePath = context.CarsImages.Where(w => w.CarId == c.CarId).FirstOrDefault().ImagePath,
                                
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetCarColorDetailDtos(int colorId)
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors.Where(w => w.ColorId == colorId)
                             on c.ColorId equals c1.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = b.BrandName,
                                 ColorName = c1.ColorName,
                                 colorId=c1.ColorId,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModeLYear,
                                 MinFindexScore = c.MinFindexScore,
                                 ImagePath = context.CarsImages.Where(w => w.CarId == c.CarId).FirstOrDefault().ImagePath,
                             };
                return result.ToList();

            }
        }
        public List<CarDetailDto> GetCarImage(int carId)
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                var result = from c in context.Cars.Where(w =>w.CarId == carId)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors
                             on c.ColorId equals c1.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = b.BrandName,
                                 ColorName = c1.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModeLYear,
                                 MinFindexScore=c.MinFindexScore,
                                 ImagePath = context.CarsImages.Where(w => w.CarId == c.CarId).FirstOrDefault().ImagePath

                             };
                return result.ToList();

            }
        }
    }
}
