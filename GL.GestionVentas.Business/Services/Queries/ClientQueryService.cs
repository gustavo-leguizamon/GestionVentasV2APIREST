using GL.GestionVentas.Business.Services.Queries.Base;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries.Base;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business.Services.Queries
{
    public class ClientQueryService : BaseQueryService<Cliente>, IClientQueryService
    {
        public ClientQueryService(IQuery<Cliente> query) : base(query)
        {
        }
    }
}
