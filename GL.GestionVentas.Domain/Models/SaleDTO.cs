﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Models
{
    public class SaleDTO
    {
        public int ClienteId { get; set; }
        public CartDTO Cart { get; set; }
    }
}
