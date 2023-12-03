using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;  // Asegúrate de importar el espacio de nombres correcto
using Business; // Importa los servicios necesarios
using Business.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoService _service;

        public GrupoController(IGrupoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Grupo grupo)
        {
            int idGrupo = _service.Add(grupo);
            return Ok(idGrupo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();
            Grupo grupo = _service.Get(id);
            if (grupo == null) return NotFound();
            return Ok(grupo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest();
            bool result = _service.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Grupo grupo)
        {
            if (grupo == null) return BadRequest();
            if (grupo.Id <= 0) return BadRequest();
            return Ok(_service.Update(grupo));
        }

        [HttpGet("{id}/notas")]
        public async Task<ActionResult> GetNotas([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            List<Nota> result = _service.GetNotas(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
