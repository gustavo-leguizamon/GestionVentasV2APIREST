using AutoMapper;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GL.GestionVentas.Business.Mappers
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Cliente, ClientDTO>(); // means you want to map from <> to <>
            CreateMap<ClientDTO, Cliente>(); // means you want to map from <> to <>

            CreateMap<Producto, ProductDTO>();
            CreateMap<ProductDTO, Producto>();

            CreateMap<Carrito, CartDTO>();
            CreateMap<CartDTO, Carrito>();

            CreateMap<Ventas, SaleDTO>();
            CreateMap<SaleDTO, Ventas>()
                .ForMember(dest => dest.Carrito, opt => opt.MapFrom(src => src.Carrito))
                .ForMember(dest => dest.PrecioTotal, opt => opt.MapFrom(src => src.TotalPrice));

            CreateMap<Ventas, DailySaleDTO>()
                .ForMember(dest => dest.VentaId, opt => opt.MapFrom(src => src.VentasId))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Carrito.Cliente))
                .ForMember(dest => dest.Productos, opt => opt.MapFrom(src => src.Carrito.CarritoProducto.Select(x => x.Producto).ToList()));

            CreateMap<Ventas, CustomerPurchaseDTO>()
                .ForMember(dest => dest.SaleId, opt => opt.MapFrom(src => src.VentasId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Fecha.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(dest => dest.QuantityProducts, opt => opt.MapFrom(src => src.Carrito.CarritoProducto.Sum(x => x.Cantidad)))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.PrecioTotal))
                .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.EstadoId))
                ;
        }
    }
}
