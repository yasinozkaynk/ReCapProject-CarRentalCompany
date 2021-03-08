using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Apstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFremawork
{
    public class EfUserDal : EfEntityRepositoryBase<User,EfRentaCar>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EfRentaCar())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
