using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
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
        IResult Update(User user);
        IDataResult<List<User>>GetById(int userId);
        IDataResult<List<UserRentalsCarDto>> GetRentalByUserId(int userId);

    }
}
