using GL.GestionVentas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business
{
    public class ClientBusiness : ContextBusiness<Cliente>
    {
        public ClientBusiness(DbContext context) : base(context)
        {
        }

        public void RegisterClient()
        {
            Console.WriteLine("Escriba DNI:");
            var dni = Console.ReadLine();
            Console.WriteLine("Escriba el nombre:");
            var name = Console.ReadLine();
            Console.WriteLine("Escriba el apellido:");
            var lastname = Console.ReadLine();
            Console.WriteLine("Escriba una dirección:");
            var address = Console.ReadLine();
            Console.WriteLine("Escriba un teléfono(opcional):");
            var phoneNumber = Console.ReadLine();

            var client = new Cliente();
            client.DNI = dni;
            client.Nombre = name;
            client.Apellido = lastname;
            client.Direccion = address;
            client.Telefono = phoneNumber;

            AddEntity(client);
        }
    }
}
