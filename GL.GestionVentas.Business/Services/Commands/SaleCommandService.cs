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

        public void RegisterSale(SaleDTO saleDto)
        {
            var sale = Mapper.Map<Ventas>(saleDto);
            sale.Fecha = DateTime.Now;
            sale.Carrito.ClienteId = saleDto.ClienteId;
            var carts = new List<CarritoProducto>();
            carts.AddRange(saleDto.Carrito.Productos.Select(x => new CarritoProducto() { ProductoId = x.ProductoId }));

            Mapper.Map(carts, sale.Carrito.CarritoProducto);

            Command.Add(sale);
        }
    }
}
