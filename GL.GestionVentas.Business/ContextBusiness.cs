using GL.GestionVentas.Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GL.GestionVentas.Business
{
    public class ContextBusiness<E> where E : class
    {
        protected DbContext Context;
        public ContextBusiness(DbContext context)
        {
            Context = context;
        }

        public virtual IQueryable<E> GetEntityBy(Expression<Func<E, bool>> predicate)
        {
            //using (var context = new EntitiesContext())
            //{
            //var context = new EntitiesContext();
            IQueryable<E> query = Context.Set<E>().Where(predicate);
            return query;
            //}
        }

        public virtual E GetEntityById(int id)
        {
            //using (var context = new EntitiesContext())
            //{
            //var context = new EntitiesContext();
            return Context.Set<E>().Find(id);
            //}
        }

        public virtual void AddEntity(E entity)
        {
            //using (var context = new EntitiesContext())
            //{
            //context.Set<E>().Add(entity);
            //var context = new EntitiesContext();
            Context.Add(entity);
            Context.SaveChanges();
            //}
        }

        public virtual IQueryable<E> GetEntities(Expression<Func<E, bool>> expression)
        {
            IQueryable<E> query = Context.Set<E>().Where(expression);
            return query;
        }
    }
}
