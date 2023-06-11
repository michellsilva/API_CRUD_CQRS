using AvaliacaoFC.Nucleo.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoFC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<Usuario> _logger;

        public UsuarioController(ILogger<Usuario> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Usuario))]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
