using AutoMapper;
using GL.GestionVentas.Business.Services.Commands.Base;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.GestionVentas.Business.Services.Commands
{
    public class ProductCommandService : BaseCommandService<Producto>, IProductCommandService
    {
        public ProductCommandService(IProductCommandRepository command, IMapper mapper) : base(command, mapper)
        {
        }
    }
}
