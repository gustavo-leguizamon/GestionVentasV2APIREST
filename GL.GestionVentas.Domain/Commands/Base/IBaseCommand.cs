using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GL.GestionVentas.Domain.Commands.Base
{
    public interface IBaseCommand<E> where E : class
    {
        void Add(E entity);
        void Delete(E entity);
        void Delete(int id);
        void Edit(E entity);
        void Save();
        Task<int> SaveAsync();
        void Detach(E entity);
        void AddRange(IEnumerable<E> entity);
        void DeleteRange(IEnumerable<E> entity);
    }
}
