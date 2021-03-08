using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Apstract
{
    public interface IUserService
    {

        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

    }
}
