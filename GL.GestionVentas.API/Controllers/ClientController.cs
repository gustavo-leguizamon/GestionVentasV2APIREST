using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using GL.GestionVentas.Domain.Models;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GL.GestionVentas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientCommandService _command;
        private readonly IClientQueryService _query;

        public ClientController(IClientCommandService command, IClientQueryService query)
        {
            _command = command;
            _query = query;
        }

        [HttpPost]
        public ActionResult RegisterClient([FromBody]ClientDTO client)
        {
            try
            {
                _command.RegisterClient(client);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<ClientDTO>> GetClients()
        {
            try
            {
                var clients = _query.GetAllClients();
                return Ok(clients);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByDNI/{dni}")]
        public ActionResult<List<ClientDTO>> GetClientsByDNI(string dni)
        {
            try
            {
                var clients = _query.GetClientsByDNI(dni);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByName/{name}/{lastname}")]
        public ActionResult<List<ClientDTO>> GetClientsByName(string name, string lastname)
        {
            try
            {
                var clients = _query.GetClientsByName(name, lastname);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}