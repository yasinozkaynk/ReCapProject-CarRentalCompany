using Business.Apstract;
using Core.Utilities.Results;
using DataAccess.Apstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class FindexManager:IFindexService
    {
        IFindexDal _findexDal;
        public FindexManager(IFindexDal findexDal)
        {
            _findexDal = findexDal;       
        }

        public IResult Add(Findex findex)
        {
            _findexDal.Add(findex);
            return new SuccessResult();
        }

        public IResult Delete(Findex findex)
        {
            _findexDal.Delete(findex);
            return new SuccessResult();
        }

        public IDataResult<Findex> GetById(int id)
        {
            return new SuccessDataResult<Findex>(_findexDal.Get(a => a.Id == id));
        }

        public IDataResult<List<Findex>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Findex>>(_findexDal.GetAll(p => p.UserId == userId).ToList());
        }

        public IResult Update(Findex findex)
        {
            _findexDal.Update(findex);
            return new SuccessResult();
        }
    }
}
