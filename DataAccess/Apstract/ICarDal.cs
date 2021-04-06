using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Apstract
{
    public interface ICarDal:IEntityRepostory<Car>
    {
        List<CarDetailDto> GetCarImage(int carId);
        List<CarDetailDto> GetCarColorDetailDtos(int colorId);
        List<CarDetailDto> GetCarBrandDetailDtos(int brandId);
        List<CarDetailDto> GetCar();
    }
}
