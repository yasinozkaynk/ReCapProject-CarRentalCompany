using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Apstract
{
    public interface ICarDal:IEntityRepostory<Car>
    {
        List<CarDetailDto> GetCarDetailDtos();
    }
}
