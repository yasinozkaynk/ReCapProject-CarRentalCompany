using Business.Apstract;
using Business.Constants;
using Core.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Apstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManeger : ICarImageService
    {
        ICarsImageDal _carsImageDal;
        public CarImageManeger(ICarsImageDal carsImageDal)
        {
            _carsImageDal = carsImageDal;
        }
        
        public IResult Add(IFormFile file ,CarsImage carsImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarsImageLimit(carsImage.CarId));
            if (result != null)
            {
                return result;
            }
            carsImage.ImagePath = FileHelper.Add(file);
            carsImage.Date = DateTime.Now;
            _carsImageDal.Add(carsImage);
            return new SuccessResult(CarMessages.CarsAdded);
        }

        public IResult Delete(CarsImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarsImageLimit(carImage.Id));

           if (result.Success)
           {
                return result;
           }
            _carsImageDal.Delete(carImage);
           return new SuccessResult();

        }

        public IDataResult<CarsImage> Get(int id)
        {
            return new SuccessDataResult<CarsImage>(_carsImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarsImage>> GetAll()
        {
            return new SuccessDataResult<List<CarsImage>>(_carsImageDal.GetAll());
        }

        public IDataResult<List<CarsImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarsImage>>(_carsImageDal.GetAll(p => p.CarId == id));
        }

        public IResult Update(IFormFile file,CarsImage carImage)
        {
            IResult result = BusinessRules.Run();

            if (result.Success)
            {
                return result;
            }
            return null;
        }


        private IResult CheckIfCarsImageLimit(int ıd)
        {
            var imagecount = _carsImageDal.GetAll(p => p.CarId == ıd).Count;
            if (imagecount == 5 ==true)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult(Messages.CarImageLimitExceded);
        }
    }
}
