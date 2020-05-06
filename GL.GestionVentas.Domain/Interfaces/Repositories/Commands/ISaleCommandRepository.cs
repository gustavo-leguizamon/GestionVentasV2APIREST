using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Repositories.Commands
{
    public interface ISaleCommandRepository : ICommand<Ventas>
    {

    }
}
