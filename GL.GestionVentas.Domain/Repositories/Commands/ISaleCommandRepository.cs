using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Repositories.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Repositories.Commands
{
    public interface ISaleCommandRepository : ICommand<Ventas>
    {

    }
}
