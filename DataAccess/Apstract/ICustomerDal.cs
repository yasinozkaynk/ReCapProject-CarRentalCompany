﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Apstract
{
    public interface ICustomerDal:IEntityRepostory<Customer>
    {
    }
}
