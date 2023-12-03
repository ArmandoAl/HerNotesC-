using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private readonly INotaService _service;

        public NotaController(INotaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddNoteModel addNotaModel)
        {
            if (addNotaModel == null) return BadRequest("Datoas invalidos");

            return Ok(_service.Add(addNotaModel));

        }   

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();
            Nota nota = _service.Get(id);
            if (nota == null) return NotFound();
            return Ok(nota);
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
        public async Task<ActionResult> Update([FromBody] Nota nota)
        {
            if (nota == null) return BadRequest();
            if (nota.Id <= 0) return BadRequest();
            return Ok(_service.Update(nota));
        }

        [HttpGet("{id}/emociones")]
        public async Task<ActionResult> GetEmociones([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            List<Emocion> result = _service.GetEmociones(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("addNotations")]

        public async Task<ActionResult> AddNotations(AnotacionesModel model)
        {
            if(model == null) return BadRequest();

            return Ok(_service.addNotations(model));
        }
    }
}
