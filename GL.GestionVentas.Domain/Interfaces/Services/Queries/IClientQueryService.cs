using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Services.Queries.Base;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Services.Queries
{
    public interface IClientQueryService : IQueryService<Cliente>
    {
        List<ClientDTO> GetAllClients();
        List<ClientDTO> GetClientsByDNI(string dni);
        List<ClientDTO> GetClientsByName(string name, string lastname);
    }
}
