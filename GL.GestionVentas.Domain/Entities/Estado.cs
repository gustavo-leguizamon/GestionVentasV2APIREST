using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Entities
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
