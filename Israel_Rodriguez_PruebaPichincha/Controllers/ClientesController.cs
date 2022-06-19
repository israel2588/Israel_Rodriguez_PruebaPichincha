using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMySql.Model;
using NetCoreMySQL.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Israel_Rodriguez_PruebaPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClient()
        {
            return Ok(await _clienteRepository.GetAllClient());
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _clienteRepository.InsertClient(cliente);

            return Created("created", created);
        }


    }
}
