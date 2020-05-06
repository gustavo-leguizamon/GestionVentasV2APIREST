using GL.GestionVentas.Business.Services.Queries.Base;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Repositories.Queries;
using GL.GestionVentas.Domain.Repositories.Queries.Base;
using GL.GestionVentas.Domain.Services.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business.Services.Queries
{
    public class ProductQueryService : BaseQueryService<Producto>, IProductQueryService
    {
        public ProductQueryService(IProductQueryRepository query) : base(query)
        {
        }
    }
}
