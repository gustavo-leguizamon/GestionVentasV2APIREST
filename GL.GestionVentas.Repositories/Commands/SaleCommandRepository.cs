using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Repositories.Commands;
using GL.GestionVentas.Repositories.Commands.Base;
using GL.GestionVentas.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Commands
{
    public class SaleCommandRepository : CommandRepository<Ventas>, ISaleCommandRepository
    {
        public SaleCommandRepository(GestionVentasContext context) : base(context)
        {
        }
    }
}
