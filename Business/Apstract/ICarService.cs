using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic; 
using System.Text;

namespace Business.Apstract
{
    public interface ICarService
    {
    
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<Car>> GetByDailyPrice(decimal min,decimal max);
        IDataResult<List<Car>> GetById(int id);
        IDataResult<List<Car>> GetByModelYear(string year);
        IDataResult<List<CarDetailDto>> CarDetailDtos();



    }
}
