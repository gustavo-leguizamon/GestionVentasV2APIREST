using AutoMapper;
using GL.GestionVentas.Business.Services.Commands.Base;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands.Base;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business.Services.Commands
{
    public class ClientCommandService : BaseCommandService<Cliente>, IClientCommandService
    {
        public ClientCommandService(IClientCommandRepository command, IMapper mapper) : base(command, mapper)
        {
        }

        public void RegisterClient(ClientDTO client)
        {
            var entity = Mapper.Map<Cliente>(client);
            Add(entity);
        }
    }
}
