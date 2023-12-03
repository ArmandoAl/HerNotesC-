using Business.Contracts;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _service = usuarioService;

        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(Login login)
        {
            if (login.email == null || login.password == null) return BadRequest();

            var usuario = _service.login(login.email, login.password);

            if (usuario != null) return Ok(usuario);

            return BadRequest();
        }
    }
}
