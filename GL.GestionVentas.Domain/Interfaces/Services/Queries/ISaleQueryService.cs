﻿using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Services.Queries.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Domain.Interfaces.Services.Queries
{
    public interface ISaleQueryService : IQueryService<Ventas>
    {

        List<Ventas> DailySalesReport();
        List<Ventas> GetProductInDailyReport(string productCode);
    }
}