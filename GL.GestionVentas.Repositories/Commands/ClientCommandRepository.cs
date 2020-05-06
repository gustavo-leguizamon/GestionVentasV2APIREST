using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands;
using GL.GestionVentas.Repositories.Commands.Base;
using GL.GestionVentas.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Commands
{
    public class ClientCommandRepository : CommandRepository<Cliente>, IClientCommandRepository
    {
        public ClientCommandRepository(GestionVentasContext context) : base(context)
        {
        }
    }
}
