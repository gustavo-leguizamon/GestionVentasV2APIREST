using GL.GestionVentas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business
{
    public class ProductBusiness : ContextBusiness<Producto>
    {
        public ProductBusiness(DbContext context) : base(context)
        {
        }


    }
}
