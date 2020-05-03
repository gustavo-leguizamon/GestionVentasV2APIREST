using GL.GestionVentas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GL.GestionVentas.Business
{
    public class SaleBusiness : ContextBusiness<Ventas>
    {
        public SaleBusiness(DbContext context) : base(context)
        {
        }

        public override IQueryable<Ventas> GetEntities(Expression<Func<Ventas, bool>> expression)
        {
            IQueryable<Ventas> query = Context.Set<Ventas>()
                                                .Include(x => x.Cliente)
                                                .Include(x => x.Producto)
                                                .Where(expression);
            return query;
        }

        public void RegisterSale()
        {
            Producto product = GetProduct();
            Cliente client = GetClient();

            Ventas sale = new Ventas();
            sale.Cliente = client;
            sale.Producto = product;
            sale.Fecha = DateTime.Now;

            AddEntity(sale);
        }

        public List<Ventas> DaySalesReport()
        {
            var sales = GetEntities(x => x.Fecha.DayOfYear >= DateTime.Now.DayOfYear);
            return sales.ToList();
        }

        public List<Ventas> SearchProductInDailyReport()
        {
            var product = GetProduct();
            var sales = DaySalesReport().Where(x => x.Producto.Codigo.Equals(product.Codigo));
            return sales.ToList();
        }

        private Cliente GetClient()
        {
            Cliente client;
            do
            {
                client = GetClientByDNI();
                if (client == null)
                    Console.WriteLine("No existe el cliente");
            }
            while (client == null);

            return client;
        }

        private Cliente GetClientByDNI()
        {
            Console.WriteLine("Ingrese DNI del cliente:");
            string dni = Console.ReadLine();
            Cliente client = new ClientBusiness(Context).GetEntityBy(x => x.DNI.Equals(dni)).FirstOrDefault();
            return client;
        }

        private Producto GetProduct()
        {
            Producto product;
            do
            {
                product = GetProductByCode();
                if (product == null)
                    Console.WriteLine("No existe el producto");
            }
            while (product == null);

            return product;
        }

        private Producto GetProductByCode()
        {
            Console.WriteLine("Ingrese código de producto:");
            string code = Console.ReadLine();
            Producto product = new ProductBusiness(Context).GetEntityBy(x => x.Codigo.Equals(code)).FirstOrDefault();
            return product;
        }


    }
}
