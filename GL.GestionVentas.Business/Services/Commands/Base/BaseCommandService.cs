using GL.GestionVentas.Domain.Repositories.Commands.Base;
using GL.GestionVentas.Domain.Services.Commands.Base;
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

        public void Add(E entity)
        {
            Command.Add(entity);
        }

        public void AddRange(IEnumerable<E> entities)
        {
            Command.AddRange(entities);
        }

        public void Delete(E entity)
        {
            Command.Delete(entity);
        }

        public void Delete(int id)
        {
            Command.Delete(id);
        }

        public void DeleteRange(IEnumerable<E> entities)
        {
            Command.DeleteRange(entities);
        }

        public void Detach(E entity)
        {
            Command.Detach(entity);
        }

        public void Edit(E entity)
        {
            Command.Edit(entity);
        }

        public void EditRange(IEnumerable<E> entities)
        {
            Command.EditRange(entities);
        }

        public void Save()
        {
            Command.Save();
        }

        public Task<int> SaveAsync()
        {
            return Command.SaveAsync();
        }
    }
}
