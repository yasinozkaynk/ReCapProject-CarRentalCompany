using Business.Apstract;
using Core.Utilities.Results;
using DataAccess.Apstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CrediCardManager:ICrediCardService
    {
        ICrediCardDal _crediCardDal;
        public CrediCardManager(ICrediCardDal crediCardDal)
        {
            _crediCardDal = crediCardDal;
          
        }
        public IDataResult<List<CrediCard>> GetAll()
        {
            return new SuccessDataResult<List<CrediCard>>(_crediCardDal.GetAll());
        }

    }

}
