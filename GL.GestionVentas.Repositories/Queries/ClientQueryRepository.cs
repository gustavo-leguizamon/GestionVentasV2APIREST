using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Repositories.Queries;
using GL.GestionVentas.Repositories.Contexts;
using GL.GestionVentas.Repositories.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Queries
{
    public class ClientQueryRepository : QueryRepository<Cliente>, IClientQueryRepository
    {
        public ClientQueryRepository(GestionVentasContext context) : base(context)
        {
        }
    }
}
