using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message) : base(message)
        {
        }
    }
}
