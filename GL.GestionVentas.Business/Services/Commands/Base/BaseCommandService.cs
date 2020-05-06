using GL.GestionVentas.Domain.Interfaces.Repositories.Commands.Base;
using GL.GestionVentas.Domain.Interfaces.Services.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GL.GestionVentas.Business.Services.Commands.Base
{
    public class BaseCommandService<E> : ICommandService<E> where E : class
    {
        protected readonly ICommand<E> Command;

        public BaseCommandService(ICommand<E> command)
        {
            Command = command;
        }

        public virtual void Add(E entity)
        {
            Command.Add(entity);
        }

        public virtual void AddRange(IEnumerable<E> entities)
        {
            Command.AddRange(entities);
        }

        public virtual void Delete(E entity)
        {
            Command.Delete(entity);
        }

        public virtual void Delete(int id)
        {
            Command.Delete(id);
        }

        public virtual void DeleteRange(IEnumerable<E> entities)
        {
            Command.DeleteRange(entities);
        }

        public virtual void Detach(E entity)
        {
            Command.Detach(entity);
        }

        public virtual void Edit(E entity)
        {
            Command.Edit(entity);
        }

        public virtual void EditRange(IEnumerable<E> entities)
        {
            Command.EditRange(entities);
        }

        public virtual void Save()
        {
            Command.Save();
        }

        public virtual Task<int> SaveAsync()
        {
            return Command.SaveAsync();
        }
    }
}
