using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Models;
using GL.GestionVentas.Domain.Interfaces.Services.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Services.Commands
{
    public interface ISaleCommandService : ICommandService<Ventas>
    {
        void RegisterSale(SaleDTO sale);
    }
}
