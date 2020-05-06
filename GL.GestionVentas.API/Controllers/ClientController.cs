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
    }
}