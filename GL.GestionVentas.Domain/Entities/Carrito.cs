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
    }
}
