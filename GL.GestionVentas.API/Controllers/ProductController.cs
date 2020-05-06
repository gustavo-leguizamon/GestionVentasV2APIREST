using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using GL.GestionVentas.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GL.GestionVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductCommandService _command;

        public ProductController(IProductCommandService command)
        {
            _command = command;
        }

        [HttpPost]
        public ActionResult RegisterProduct([FromBody]ProductDTO product)
        {
            try
            {
                _command.RegisterProduct(product);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}