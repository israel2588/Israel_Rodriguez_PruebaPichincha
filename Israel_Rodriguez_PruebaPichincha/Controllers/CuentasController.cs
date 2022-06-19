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
    public class CuentasController : Controller
    {

        private readonly ICuentaRepository _cuentaRepository;

        public CuentasController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            return Ok(await _cuentaRepository.GetAllAccount());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuenta([FromBody] Cuenta cuenta)
        {
            if (cuenta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _cuentaRepository.InsertAccount(cuenta);

            return Created("created", created);
        }

        


    }
}
