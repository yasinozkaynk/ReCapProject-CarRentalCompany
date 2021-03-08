using Core.DataAccess;
using DataAccess.Apstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFremawork
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer,EfRentaCar>,ICustomerDal
    {
       
    }
}
