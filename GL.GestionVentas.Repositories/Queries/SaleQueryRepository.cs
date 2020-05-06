using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries;
using GL.GestionVentas.Repositories.Contexts;
using GL.GestionVentas.Repositories.Queries.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Queries
{
    public class SaleQueryRepository : QueryRepository<Ventas>, ISaleQueryRepository
    {
        public SaleQueryRepository(GestionVentasContext context) : base(context)
        {
        }
    }
}
