using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Entities
{
    public class Carrito
    {
        public int CarritoId { get; set; }
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; }

        public Carrito()
        {
            Ventas = new HashSet<Ventas>();
            CarritoProductos = new HashSet<CarritoProducto>();
        }
    }
}
