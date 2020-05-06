using GL.GestionVentas.Business.Exceptions;
using GL.GestionVentas.Business.Services.Commands.Base;
using GL.GestionVentas.Business.Services.Queries;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Models;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands.Base;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using GL.GestionVentas.Repositories.Contexts;
using GL.GestionVentas.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace GL.GestionVentas.Business.Services.Commands
{
    public class SaleCommandService : BaseCommandService<Ventas>, ISaleCommandService
    {
        public SaleCommandService(ISaleCommandRepository command, IMapper mapper) : base(command, mapper)
        {
        }

        public void RegisterSale(SaleDTO sale)
        {
            Producto product;
            Cliente client;
            using (var context = new GestionVentasContext())
            {
                product = new ProductQueryService(new ProductQueryRepository(context)).FindBy(x => x.Codigo.Equals(sale.ProductCode)).FirstOrDefault();
                if (product == null)
                    throw new ProductNotFoundException($"No existe el producto con el código: {sale.ProductCode}");

                client = new ClientQueryService(new ClientQueryRepository(context)).FindBy(x => x.DNI.Equals(sale.Dni)).FirstOrDefault();
                if (client == null)
                    throw new ClientNotFoundException($"No existe cliente con el DNI: {sale.Dni}");

            }

            var newSale = new Ventas()
            {
                ClienteId = client.ClienteId,
                ProductoId = product.ProductoId,
                Fecha = DateTime.Now
            };

            Command.Add(newSale);
        }
    }
}
