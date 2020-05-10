using AutoMapper;
using GL.GestionVentas.Business.Services.Queries.Base;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries.Base;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GL.GestionVentas.Business.Services.Queries
{
    public class SaleQueryService : BaseQueryService<Ventas>, ISaleQueryService
    {
        public SaleQueryService(ISaleQueryRepository query, IMapper mapper) : base(query, mapper)
        {
        }

        public List<DailySaleDTO> DailySalesReport()
        {
            var sales = FindBy(x => x.Fecha.DayOfYear >= DateTime.Now.DayOfYear, new string[] { "Carrito",
                                                                                                "Carrito.Cliente",
                                                                                                "Carrito.CarritoProducto",
                                                                                                "Carrito.CarritoProducto.Producto" }).ToList();

            var dailySales = Mapper.Map<List<DailySaleDTO>>(sales);

            return dailySales;
        }

        public List<DailySaleDTO> GetProductInDailyReport(int productId)
        {
            var salesOfTheDay = DailySalesReport();
            return salesOfTheDay.Where(x => x.Productos.Where(y => y.ProductoId == productId).Any()).ToList();
        }
    }
}
