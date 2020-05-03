using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Entities
{
    public class Ventas
    {
        public int VentasId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
