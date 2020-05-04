using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GL.GestionVentas.Domain.Services.Queries.Base
{
    public interface IQueryService<E> where E : class
    {
        void Detach(E entity);
        IQueryable<E> FindBy(Expression<Func<E, bool>> predicate);
        E FindById(int id);
        IQueryable<E> GetAll();
    }
}
