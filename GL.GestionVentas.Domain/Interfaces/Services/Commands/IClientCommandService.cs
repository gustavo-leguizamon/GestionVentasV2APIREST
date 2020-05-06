using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Services.Commands.Base;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Services.Commands
{
    public interface IClientCommandService : ICommandService<Cliente>
    {
        void RegisterClient(ClientDTO client);
    }
}
