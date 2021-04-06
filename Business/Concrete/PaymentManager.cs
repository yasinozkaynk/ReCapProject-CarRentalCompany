using Business.Apstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Apstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager:IPaymentService
    {
        IPaymentDal _paymentDal;
        IRentalService _rentalService;
        public PaymentManager(IPaymentDal paymentDal,IRentalService rentalService)
        {
            _paymentDal = paymentDal;
            _rentalService = rentalService;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult();
        }
    }
}
