using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios
{
    public class ExecutorListarUsuarios : IRequestHandler<ConsultaListarUsuarios, RespostaListarUsuarios>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorListarUsuarios(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaListarUsuarios> Handle(ConsultaListarUsuarios comando, CancellationToken cancellationToken)
        {

            Expression<Func<Usuario, bool>> expressao = usuario => true;

            if (!String.IsNullOrEmpty(comando.Nome))
            {
                Expression<Func<Usuario, bool>> nome = o => o.Nome.ToLower().Contains(comando.Nome.Trim().ToLower());
                expressao = expressao.And(nome);
            }
            if (!String.IsNullOrEmpty(comando.Cpf))
            {
                Expression<Func<Usuario, bool>> cpf = o => o.Cpf.Trim() == comando.Cpf.Trim();
                expressao = expressao.And(cpf);
            }
            if (!String.IsNullOrEmpty(comando.Login))
            {
                Expression<Func<Usuario, bool>> login = o => o.Login.ToLower() == comando.Login.Trim().ToLower();
                expressao = expressao.And(login);
            }
            if (comando.Status != null)
            {
                Expression<Func<Usuario, bool>> status = o => o.Status == (Usuario.Situacao)comando.Status;
                expressao = expressao.And(status);
            }
            if (comando.InicioInclusao != null)
            {
                Expression<Func<Usuario, bool>> inclusaoInicio = o => o.DataInclusao >= comando.InicioInclusao;
                expressao = expressao.And(inclusaoInicio);
            }
            if (comando.FinalInclusao != null)
            {
                Expression<Func<Usuario, bool>> inclusaoFinal = o => o.DataInclusao <= comando.FinalInclusao;
                expressao = expressao.And(inclusaoFinal);
            }
            if (comando.InicioNascimento != null)
            {
                Expression<Func<Usuario, bool>> nascimentoInicio = o => o.DataNascimento >= comando.InicioNascimento;
                expressao = expressao.And(nascimentoInicio);
            }
            if (comando.FinalNascimento != null)
            {
                Expression<Func<Usuario, bool>> nascimentoFinal = o => o.DataNascimento <= comando.FinalNascimento;
                expressao = expressao.And(nascimentoFinal);
            }
            if (comando.InicioAlteracao != null)
            {
                Expression<Func<Usuario, bool>> alteracaoInicio = o => o.DataAlteracao >= comando.InicioAlteracao;
                expressao = expressao.And(alteracaoInicio);
            }
            if (comando.FinalAlteracao != null)
            {
                Expression<Func<Usuario, bool>> alteracaoFinal = o => o.DataAlteracao <= comando.FinalAlteracao;
                expressao = expressao.And(alteracaoFinal);
            }
            if (comando.InicioIdade != null)
            {
                var dataFiltro = DateTime.Now.AddYears((int)-comando.InicioIdade);
                Expression<Func<Usuario, bool>> idadeInicio = o => o.DataNascimento < dataFiltro;
                expressao = expressao.And(idadeInicio);
            }
            if (comando.FinalIdade != null)
            {
                var dataFiltro = DateTime.Now.AddYears((int)-comando.FinalIdade);
                Expression<Func<Usuario, bool>> idadeFinal = o => o.DataNascimento > dataFiltro;
                expressao = expressao.And(idadeFinal);
            }

            var usuarios = _repositorioUsuario.FiltrarComPaginacao(expressao, comando.pagInicial, comando.pagFinal);
            var totalRegistros = _repositorioUsuario.ObterTotalRegistros(expressao);

            _logger.LogInformation("Usuários listados com sucesso!");

            return Task.FromResult(RespostaListarUsuarios.Sucesso(usuarios, totalRegistros));
        }
    }
}
