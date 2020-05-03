using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
