using AvaliacaoFC.Nucleo.Aplicacao;
using AvaliacaoFC.Nucleo.Aplicacao.AtivarUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.AtualizarUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.BloquearUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.InativarTodosUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.InativarUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios;
using AvaliacaoFC.Nucleo.Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoFC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<Usuario> _log;
        private readonly IMediator _mediador;
        public UsuarioController(ILogger<Usuario> log, IMediator mediador)
        {
            _log = log;
            _mediador = mediador;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(RespostaListarUsuarios))]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var resposta = await _mediador.Send(new ConsultaListarUsuarios());

                if (resposta.Sucesso)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest(resposta);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Ocorreu um erro não conhecido.");

                return StatusCode(500, new RespostaBase(false, "Ocorreu um erro não conhecido."));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComandoCadastrarUsuario comando)
        {
            try
            {
                var resposta = await _mediador.Send(comando);

                if (resposta.Sucesso)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest(resposta);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Ocorreu um erro não conhecido.");

                return StatusCode(500, new RespostaBase(false, "Ocorreu um erro não conhecido."));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ComandoAtualizarUsuario comando)
        {
            try
            {
                var resposta = await _mediador.Send(comando);

                if (resposta.Sucesso)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest(resposta);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Ocorreu um erro não conhecido.");

                return StatusCode(500, new RespostaBase(false, "Ocorreu um erro não conhecido."));
            }
        }

        [HttpPost("Inativar")]
        public async Task<IActionResult> Inativar([FromBody] ComandoInativarUsuario comando)
        {
            try
            {
                var resposta = await _mediador.Send(comando);

                if (resposta.Sucesso)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest(resposta);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Ocorreu um erro não conhecido.");

                return StatusCode(500, new RespostaBase(false, "Ocorreu um erro não conhecido."));
            }
        }

        [HttpPost("Bloquear")]
        public async Task<IActionResult> Bloquear([FromBody] ComandoBloquearUsuario comando)
        {
            try
            {
                var resposta = await _mediador.Send(comando);

                if (resposta.Sucesso)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest(resposta);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Ocorreu um erro não conhecido.");

                return StatusCode(500, new RespostaBase(false, "Ocorreu um erro não conhecido."));
            }
        }
        
        [HttpPost("Ativar")]
        public async Task<IActionResult> Ativar([FromBody] ComandoAtivarUsuario comando)
        {
            try
            {
                var resposta = await _mediador.Send(comando);

                if (resposta.Sucesso)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest(resposta);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Ocorreu um erro não conhecido.");

                return StatusCode(500, new RespostaBase(false, "Ocorreu um erro não conhecido."));
            }
        }

        [HttpPost("InativarTodos")]
        public async Task<IActionResult> InativarTodos([FromBody] ComandoInativarTodosUsuario comando)
        {
            try
            {
                var resposta = await _mediador.Send(comando);

                if (resposta.Sucesso)
                {
                    return Ok(resposta);
                }
                else
                {
                    return BadRequest(resposta);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Ocorreu um erro não conhecido.");

                return StatusCode(500, new RespostaBase(false, "Ocorreu um erro não conhecido."));
            }
        }
    }
}
