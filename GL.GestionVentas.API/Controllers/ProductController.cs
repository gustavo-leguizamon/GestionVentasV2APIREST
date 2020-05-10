using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
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
        private readonly IProductQueryService _query;

        public ProductController(IProductCommandService command, IProductQueryService query)
        {
            _command = command;
            _query = query;
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

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetProducts()
        {
            try
            {
                var products = _query.GetAllProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByCode/{productCode}")]
        public ActionResult<ProductDTO> GetProductByCode(string productCode)
        {
            try
            {
                var product = _query.GetProductByCode(productCode);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}