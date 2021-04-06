using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Apstract
{
    public interface ICrediCardService
    {
        IDataResult<List<CrediCard>> GetAll();
    }
}
