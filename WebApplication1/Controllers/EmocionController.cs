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
    public class EmocionController : ControllerBase
    {
        private readonly IEmocionService _service;

        public EmocionController(IEmocionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(Emocion emocion)
        {
            int idEmocion = _service.Add(emocion);
            return Ok(idEmocion);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();
            Emocion emocion = _service.Get(id);
            if (emocion == null) return NotFound();
            return Ok(emocion);
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

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {

            List<Emocion> emociones = _service.GetAllEmotionsFromDb();
            if (emociones != null)
            {
                return Ok(emociones);
            }
            return BadRequest("Fue desde la ruta");
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Emocion emocion)
        {
            if (emocion == null) return BadRequest();
            if (emocion.Id <= 0) return BadRequest();
            return Ok(_service.Update(emocion));
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
