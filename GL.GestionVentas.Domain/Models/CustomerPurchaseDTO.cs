using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Models
{
    public class CustomerPurchaseDTO
    {
        public int SaleId { get; set; }
        public string Date { get; set; }
        public int QuantityProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public int StateId { get; set; }
    }
}
