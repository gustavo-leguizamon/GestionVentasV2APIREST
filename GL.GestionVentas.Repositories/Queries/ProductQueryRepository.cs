using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries;
using GL.GestionVentas.Repositories.Contexts;
using GL.GestionVentas.Repositories.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Queries
{
    public class ProductQueryRepository : QueryRepository<Producto>, IProductQueryRepository
    {
        public ProductQueryRepository(GestionVentasContext context) : base(context)
        {
        }
    }
}
