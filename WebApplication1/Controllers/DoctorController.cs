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
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(DoctorUser user)
        {
            int idUser = _service.Add(user);
            return Ok(idUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();
            DoctorUser user = _service.Get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(Login login)
        {
            if (login.email == null || login.password == null) return BadRequest();

            Usuario usuario = _service.login(login.email, login.password);
            if (usuario != null && usuario.Password == login.password)
            {
                return Ok(usuario);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
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
        public async Task<ActionResult> Update([FromBody] DoctorUser usuario)
        {
            if (usuario == null) return BadRequest();
            if (usuario.Id <= 0) return BadRequest();
            return Ok(_service.Update(usuario));
        }

        [HttpGet("{id}/GetAllUsers")]
        public async Task<ActionResult> GetUsers([FromRoute] int id)
        {
            if (id <= 0) return BadRequest();

            return Ok(_service.GetUsers(id));
        }

    }
}
