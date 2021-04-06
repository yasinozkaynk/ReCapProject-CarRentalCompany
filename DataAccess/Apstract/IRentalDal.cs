using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Apstract
{
    public interface IRentalDal:IEntityRepostory<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate);
    }
}
