using GL.GestionVentas.Domain.Repositories.Queries.Base;
using GL.GestionVentas.Domain.Services.Queries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GL.GestionVentas.Business.Services.Queries.Base
{
    public class BaseQueryService<E> : IQueryService<E> where E : class
    {
        protected readonly IQuery<E> Query;

        public BaseQueryService(IQuery<E> query)
        {
            Query = query;
        }

        public void Detach(E entity)
        {
            Query.Detach(entity);
        }

        public IQueryable<E> FindBy(Expression<Func<E, bool>> predicate)
        {
            return Query.FindBy(predicate);
        }

        public E FindById(int id)
        {
            return Query.FindById(id);
        }

        public IQueryable<E> GetAll()
        {
            return Query.GetAll();
        }
    }
}
