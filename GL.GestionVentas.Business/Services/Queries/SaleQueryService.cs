using GL.GestionVentas.Business.Services.Queries.Base;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries.Base;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GL.GestionVentas.Business.Services.Queries
{
    public class SaleQueryService : BaseQueryService<Ventas>, ISaleQueryService
    {
        public SaleQueryService(ISaleQueryRepository query) : base(query)
        {
        }

        public List<Ventas> DailySalesReport()
        {
            var sales = FindBy(x => x.Fecha.DayOfYear >= DateTime.Now.DayOfYear, new string[] { "Cliente", "Producto" });
            return sales.ToList();
        }

        public List<Ventas> GetProductInDailyReport(string productCode)
        {
            var salesOfTheDay = DailySalesReport();
            //var sales = salesOfTheDay.Where(x => x.Producto.Codigo.Equals(productCode)).ToList();
            var sales = new List<Ventas>();

            return sales;
        }
    }
}
