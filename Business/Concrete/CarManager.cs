using Business.Apstract;
using DataAccess.Apstract;
using DataAccess.Concrete.EntityFremawork;
using Entities.Concrete;
using Entities.DTOs;
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
        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }
        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }
        public List<Car> GetByModelYear(string
            year)
        {
            return _carDal.GetAll(p => p.ModeLYear.Contains(year)== true);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(p => p.Id == id);
        }

        public List<CarDetailDto> carDetailDtos()
        {
            return _carDal.GetCarDetailDtos();
        }
    }
}
