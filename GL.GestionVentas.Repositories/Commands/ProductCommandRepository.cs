using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands;
using GL.GestionVentas.Repositories.Commands.Base;
using GL.GestionVentas.Repositories.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Commands
{
    public class ProductCommandRepository : CommandRepository<Producto>, IProductCommandRepository
    {
        public ProductCommandRepository(GestionVentasContext context) : base(context)
        {
        }
    }
}
