using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Entities
{
    public class CarritoProducto
    {
        public int CarritoProductoId { get; set; }
        public int CarritoId { get; set; }
        public int ProductoId { get; set; }

        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
