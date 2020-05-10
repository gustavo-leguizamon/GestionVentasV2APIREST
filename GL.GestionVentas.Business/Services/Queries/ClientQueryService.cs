using AutoMapper;
using GL.GestionVentas.Business.Services.Queries.Base;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries.Base;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business.Services.Queries
{
    public class ClientQueryService : BaseQueryService<Cliente>, IClientQueryService
    {
        public ClientQueryService(IClientQueryRepository query, IMapper mapper) : base(query, mapper)
        {
        }

        public List<ClientDTO> GetAllClients()
        {
            var clients = base.GetAll();
            return Mapper.Map<List<ClientDTO>>(clients);
        }
    }
}
