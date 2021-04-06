using Core.DataAccess;
using DataAccess.Apstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFremawork
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, EfRentaCar>, ICustomerDal
    {
        public List<CustomerDto> GetCustomerDto()
        {
            using (EfRentaCar context = new EfRentaCar())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new CustomerDto { CustomerId = c.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, PasswordSalt = u.PasswordSalt, PasswordHash = u.PasswordHash, CompanyName = c.CompanyName };
                return result.ToList();
            }
           
        }
    }
}
