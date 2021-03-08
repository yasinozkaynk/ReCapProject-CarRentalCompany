using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Apstract
{
    
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
        IDataResult<List<Color>> GetById(int id);
    }
}
