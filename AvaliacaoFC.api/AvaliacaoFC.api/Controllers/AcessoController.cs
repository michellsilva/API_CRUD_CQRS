using AvaliacaoFC.Nucleo.Aplicacao;
using AvaliacaoFC.Nucleo.Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema;
using AvaliacaoFC.Nucleo.Aplicacao.RecuperarSenhaUsuario;

namespace AvaliacaoFC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcessoController : ControllerBase
    {
        private readonly ILogger<Usuario> _log;
        private readonly IMediator _mediador;
        public AcessoController(ILogger<Usuario> log, IMediator mediador)
        {
            _log = log;
            _mediador = mediador;
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> Post([FromBody] ComandoAcessarSistema comando)
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

        [HttpPost("RecuperarSenha")]
        public async Task<IActionResult> RecuperarSenha([FromBody] ComandoRecuperarSenhaUsuario comando)
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
