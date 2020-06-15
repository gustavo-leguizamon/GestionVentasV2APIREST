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
                return Created("", "{\"result\":\"ok\"}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("DailyReport")]
        public ActionResult<List<DailySaleDTO>> DailySalesReport()
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

        [HttpGet("DailyReport/{productId}")]
        public ActionResult<List<DailySaleDTO>> GetProductInDailyReport(int productId)
        {
            try
            {
                var sales = _query.GetProductInDailyReport(productId);
                return Ok(sales);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}