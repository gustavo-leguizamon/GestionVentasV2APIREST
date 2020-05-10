using AutoMapper;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Models;
using System;
using System.Collections.Generic;
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
                .ForMember(dest => dest.Carrito, opt => opt.MapFrom(src => src.Cart));
        }
    }
}
