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
    public class PacienteController : Controller
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(PacienteUser user)
        {
            int idUser = _service.Add(user);
            return Ok(idUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();
            PacienteUser user = _service.Get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(Login login)
        {
            if (login.email == null || login.password == null) return BadRequest();

            PacienteUser usuario = _service.login(login.email, login.password);

            if (usuario != null && usuario.Password == login.password)
            {
                return Ok(usuario);
            } 

            return NotFound();
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
        public async Task<ActionResult> Update([FromBody] PacienteUser usuario)
        {
            if (usuario == null) return BadRequest();
            if (usuario.Id <= 0) return BadRequest();
            return Ok(_service.Update(usuario));
        }

        [HttpGet("{id}/notas")]
        public async Task<ActionResult> GetNotes([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            List<Nota> result = _service.GetNotes(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("{id}/relate/{pacienteid}")]
        public async Task<ActionResult> Relate([FromRoute] int id, [FromRoute] int pacienteid)
        {
            if(id <= 0) return BadRequest();
            if(id <= 1) return BadRequest();
            return Ok(_service.RelatePacienteWithDoctor(id, pacienteid));
        }

        [HttpPost("otherlogin")]
        public async Task<ActionResult> LoginOher(Login login)
        {
            if (login.email == null || login.password == null) return BadRequest();

            UserResponseModel usuario = _service.otherLogin(login.email, login.password);

            if (usuario != null) return Ok(usuario);

            return BadRequest();
        }

    }
}
