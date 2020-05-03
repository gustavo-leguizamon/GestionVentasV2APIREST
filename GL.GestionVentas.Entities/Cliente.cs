using System;
using System.Collections.Generic;

namespace GL.GestionVentas.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
