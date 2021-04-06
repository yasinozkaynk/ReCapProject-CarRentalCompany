
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Apstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarsImage>> GetAll();
        IDataResult<CarsImage> Get(int id);
        IResult Add(IFormFile file, CarsImage carImage);
        IResult Update(IFormFile file ,CarsImage carImage);
        IResult Delete(CarsImage carImage);
        IDataResult<List<CarsImage>> GetImagesByCarId(int id);
        
    }
}
