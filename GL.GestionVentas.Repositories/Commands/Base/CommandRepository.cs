//using GL.GestionVentas.Domain.Commands.Base;
using GL.GestionVentas.Domain.Repositories.Commands.Base;
using GL.GestionVentas.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GL.GestionVentas.Repositories.Commands.Base
{
    public class CommandRepository<E> : ICommand<E> where E : class
    {
        protected readonly DbContext Context;

        public CommandRepository(DbContext context)
        {
            Context = context;
        }

        public virtual void Add(E entity)
        {
            Context.Set<E>().Add(entity);
            Context.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<E> entity)
        {
            Context.Set<E>().AddRange(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(E entity)
        {
            Context.Set<E>().Attach(entity);
            Context.Set<E>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = Context.Set<E>().Find(id);
            Delete(entity);
        }

        public virtual void DeleteRange(IEnumerable<E> entity)
        {
            Context.Set<E>().RemoveRange(entity);
            Context.SaveChanges();
        }

        public virtual void Detach(E entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public virtual void Edit(E entity)
        {
           Context.Set<E>().Attach(entity);
           Context.Entry(entity).State = EntityState.Modified;
           Context.SaveChanges();
        }

        public virtual void EditRange(IEnumerable<E> entities)
        {
            Context.Set<E>().UpdateRange(entities);
            Context.SaveChanges();
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
