using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
