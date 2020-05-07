using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GL.GestionVentas.Business.Exceptions;
using GL.GestionVentas.Domain.Entities;
using GL.GestionVentas.Domain.Models;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GL.GestionVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleCommandService _command;
        private readonly ISaleQueryService _query;

        public SaleController(ISaleCommandService command, ISaleQueryService query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost]
        public ActionResult RegisterSale([FromBody]SaleDTO sale)
        {
            try
            {
                _command.RegisterSale(sale);
                return Ok();
            }
            catch (ProductNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (ClientNotFoundException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Ventas>> DailySalesReport()
        {
            try
            {
                var sales = _query.DailySalesReport();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{productCode}")]
        public ActionResult<List<Ventas>> GetProductInDailyReport(string productCode)
        {
            try
            {
                var sales = _query.GetProductInDailyReport(productCode);
                return Ok(sales);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}