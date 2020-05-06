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

            CreateMap<ClientDTO, Cliente>();
        }
    }
}
