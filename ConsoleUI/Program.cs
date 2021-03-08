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
            RentalCrudMethods();
            //CarAdded();
            //BrandManagerTest();
            //CarDetailDtoTest();
            //CarDeleted();
            //CarDetailDtoTest2();

        }
        private static void CarDetailDtoTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result= carManager.CarDetailDtos();
            foreach (var carDetailDto in result.Data)
            {
                Console.WriteLine("Araç markası : " + carDetailDto.BrandName + "  " + "Araç Rengi : " + carDetailDto.ColorName + "  " + "Araç Modeli : " + carDetailDto.ModeLYear + "  " + "Günlük Kiralama Üceti : " + carDetailDto.DailyPrice + "$");
            }
        }
        private static void CarDeleted()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            try
            {
                Car car = new Car
                {
                    CarId = 1,
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
            var result = carManager.CarDetailDtos();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "/" + car.CarId);
            }
        }

        private static void CarAdded()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Araç renkleri");
            var result = colorManager.GetAll();
            var result2 = brandManager.GetAll();
            foreach (var color in result.Data)
            {         
                Console.WriteLine(color.ColorId+":"+color.ColorName);
            }
            Console.WriteLine("------");
            Console.WriteLine("Araç Markaları");
            foreach (var brand in result2.Data)
            {
                Console.WriteLine(brand.BrandId + ":" + brand.BrandName);
            }
            Console.WriteLine("--------ARAÇ EKLEME-------");
            Car car = new Car();
            Console.Write("Lütfen Araç Modeli Id Giriniz:");
            car.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lütfen Araç Rengi Id Giriniz:");
            car.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Lütfen Günlük Kiralama Ücretini Giriniz:");
            car.DailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Lütfen Açıklama Giriniz:");
            car.Description = Convert.ToString(Console.ReadLine());
            Console.Write("Lütfen Araç model yılını Giriniz:");
            car.ModeLYear = Convert.ToString(Console.ReadLine());
            carManager.Add(car);
            Console.WriteLine("---------------------------------------BÜTÜN ARAÇLAR---------------------------------");
            CarDetailDtoTest2();
           
        }
        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(1);
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandId);                
            }
        }


        private static void RentalCrudMethods()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }

            Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = DateTime.Now }).Message);

            var result2 = rentalManager.GetAll();
            foreach (var rental in result2.Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void CustomerCrudMehods()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine("{0} {1} {2}", customer.Id, customer.UserId, customer.CompanyName);
            }
        }

    }
}
