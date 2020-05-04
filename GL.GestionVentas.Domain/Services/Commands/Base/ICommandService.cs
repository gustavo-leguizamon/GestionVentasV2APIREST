using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GL.GestionVentas.Domain.Services.Commands.Base
{
    public interface ICommandService<E> where E : class
    {
        void Add(E entity);
        void AddRange(IEnumerable<E> entities);
        void Delete(E entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<E> entities);
        void Detach(E entity);
        void Edit(E entity);
        void EditRange(IEnumerable<E> entities);
        void Save();
        Task<int> SaveAsync();
    }
}
