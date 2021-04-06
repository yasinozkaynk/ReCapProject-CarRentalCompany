using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Apstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
    }
}
