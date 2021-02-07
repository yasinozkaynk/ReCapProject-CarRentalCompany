using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Apstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
        List<Brand> GetById(int id);
    }
}
