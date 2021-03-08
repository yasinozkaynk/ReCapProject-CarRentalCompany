using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Apstract
{
    public interface IUserDal:IEntityRepostory<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
