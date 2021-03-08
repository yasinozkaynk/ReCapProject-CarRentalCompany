using Business.Apstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Apstract;
using DataAccess.Concrete.EntityFremawork;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;

using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run();

            if (result!=null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(CarMessages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarMessages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByModelYear(string year)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ModeLYear.Contains(year) == true));
           
        }

        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(10)]
        [CacheAspect]
        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(CarMessages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarId == id));
        }


        [CacheAspect]
        public IDataResult<List<CarDetailDto>> CarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDtos());
        }


        [CacheAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<10)
            {
                throw new Exception();
            }
            Add(car);
            return null;
        }
    }
}
