using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands;
using GL.GestionVentas.Repositories.Commands.Base;
using GL.GestionVentas.Repositories.Contexts;
using GL.GestionVentas.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Repositories.Commands
{
    public class SaleCommandRepository : CommandRepository<Ventas>, ISaleCommandRepository
    {
        public SaleCommandRepository(GestionVentasContext context) : base(context)
        {
        }

        public void CancelPurchase(int saleID)
        {
            var query = new SaleQueryRepository(Context);
            var sale = query.FindById(saleID);
            sale.EstadoId = 2;
            this.Edit(sale);
        }
    }
}
