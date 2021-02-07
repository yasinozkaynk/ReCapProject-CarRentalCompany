using Business.Apstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFremawork;
using Entities.Concrete;
using System;
namespace ConsoleUI
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //CarAdded();
            //BrandManagerTest();
            //CarDetailDtoTest();
            //carDeleted();

        }

        private static void carDeleted()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            try
            {
                Car car = new Car
                {
                    Id = 1,
                };
                carManager.Delete(car);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private static void CarDetailDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.carDetailDtos())
            {
                Console.WriteLine(car.Name + "/" + car.Id);
            }
        }

        private static void CarAdded()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            try
            {
                Car car = new Car
                {
                    BrandId = 1,
                    ColorId = 2,
                    DailyPrice = 0,
                    Description = "Yeni Araç",
                    ModeLYear = "2015",

                };
                carManager.Add(car);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetById(1))
            {
                Console.WriteLine(brand.Name);
            }
        }

    }
}
