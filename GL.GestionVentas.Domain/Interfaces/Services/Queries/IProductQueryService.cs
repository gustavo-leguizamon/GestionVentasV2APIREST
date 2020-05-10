using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Services.Queries.Base;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Services.Queries
{
    public interface IProductQueryService : IQueryService<Producto>
    {
        List<ProductDTO> GetAllProducts();
        ProductDTO GetProductByCode(string productCode);
    }
}
