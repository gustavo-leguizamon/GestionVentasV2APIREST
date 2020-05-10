using GL.GestionVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Models
{
    public class DailySaleDTO
    {
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public ClientDTO Cliente { get; set; }
        public List<ProductDTO> Productos { get; set; }
    }
}
