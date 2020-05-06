using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Repositories.Queries
{
    public interface ISaleQueryRepository : IQuery<Ventas>
    {
    }
}
