using GL.GestionVentas.App;
using GL.GestionVentas.Business;
using GL.GestionVentas.Entities;
using GL.GestionVentas.Entities.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GL.GestionVentas.ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }

        public static void Init()
        {
            Console.Clear();

            using(var context = new EntitiesContext())
            {
                while (true)
                {
                    ShowOptions();
                    var selectedOption = GetSelectedOption();

                    if (selectedOption == SelectedOption.Exit)
                        break;

                    switch (selectedOption)
                    {
                        case SelectedOption.RegisterSale:
                            new SaleBusiness(context).RegisterSale();
                            break;
                        case SelectedOption.WatchSales:
                            var sales = new SaleBusiness(context).DaySalesReport();
                            ShowDayReport(sales);
                            break;
                        case SelectedOption.FindProduct:
                            var salesFiltered = new SaleBusiness(context).SearchProductInDailyReport();
                            ShowDayReport(salesFiltered);
                            break;
                        case SelectedOption.RegisterClient:
                            new ClientBusiness(context).RegisterClient();
                            break;
                        default:
                            Console.WriteLine("Opción inválida \n\n");
                            break;
                    }
                }
            }
        }

        public static SelectedOption GetSelectedOption()
        {
            int selectedOption = 0;
            string option = Console.ReadLine();
            int.TryParse(option, out selectedOption);
            return (SelectedOption)selectedOption;
        }

        public static void ShowOptions()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1) Registrar venta");
            Console.WriteLine("2) Ver reporte de ventas del día");
            Console.WriteLine("3) Búsqueda de producto en listado de ventas del día");
            Console.WriteLine("4) Registrar nuevo cliente");
            Console.WriteLine("9) Salir");
        }

        public static void ShowDayReport(List<Ventas> sales)
        {
            Console.WriteLine("Reporte ventas del día");
            Console.WriteLine("Fecha\t|\tProducto\t|\tCliente\t|\tDNI");
            foreach (var item in sales)
            {
                string date = item.Fecha.ToString("dd/MM/yyyy");
                string product = item.Producto.Nombre;
                string client = $"{item.Cliente.Nombre} {item.Cliente.Apellido}";
                string dni = item.Cliente.DNI;
                Console.WriteLine($"{date}\t|\t{product}\t|\t{client}\t|\t{dni}");
            }
            Console.WriteLine("\n\n");
        }
    }
}
