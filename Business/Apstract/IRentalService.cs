using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Apstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetById(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult CheckCarStatus(Rental rental);
    }
}
