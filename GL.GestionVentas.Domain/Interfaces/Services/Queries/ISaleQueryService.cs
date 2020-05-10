using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Services.Queries.Base;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Services.Queries
{
    public interface ISaleQueryService : IQueryService<Ventas>
    {

        List<DailySaleDTO> DailySalesReport();
        List<DailySaleDTO> GetProductInDailyReport(int productId);
    }
}
