using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Apstract
{
    public interface IUserDal:IEntityRepostory<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserRentalsCarDto> GetRentalDetails(Expression<Func<UserRentalsCarDto, bool>> filter = null);

    }
}
