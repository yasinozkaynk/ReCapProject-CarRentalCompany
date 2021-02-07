using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepostory<A> where A:class,IEntity,new()
    {
        List<A> GetAll(Expression<Func<A,bool>> filter=null);
        A Get(Expression<Func<A, bool>> filter);
        void Add(A entity);
        void Update(A entity);
        void Delete(A entity);
      
    }
}
