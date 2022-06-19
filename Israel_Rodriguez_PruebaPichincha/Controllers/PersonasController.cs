using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreMySql.Model;
using NetCoreMySQL.Data.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Israel_Rodriguez_PruebaPichincha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : Controller
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonasController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllPersona()
        {
            return Ok(await _personaRepository.GetAllPerson());
        }

        
        [HttpPost]
        public async Task<IActionResult> CreatePersona([FromBody] Persona persona)
        {
            if (persona == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _personaRepository.InsertPerson(persona);

            return Created("created",created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] Persona persona)
        {

            if (persona == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _personaRepository.UpdatePerson(persona);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromBody] Persona persona)
        {
            if (persona == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _personaRepository.DeletePerson(persona);

            return NoContent();
        }

    }
}
