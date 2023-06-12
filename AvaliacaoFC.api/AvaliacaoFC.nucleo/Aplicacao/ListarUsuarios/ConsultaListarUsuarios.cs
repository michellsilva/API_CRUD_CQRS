using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios
{
    public class ConsultaListarUsuarios : IRequest<RespostaListarUsuarios>
    {
        public string? Nome { get; init; }
        public string? Cpf { get; init; }
        public string? Login { get; init; }
        public int? Status { get; init; }
        public DateTime? InicioNascimento { get; init; }
        public DateTime? FinalNascimento { get; init; }
        public DateTime? InicioInclusao { get; init; }
        public DateTime? FinalInclusao { get; init; }
        public DateTime? InicioAlteracao { get; init; }
        public DateTime? FinalAlteracao { get; init; }
        public int? InicioIdade { get; init; }
        public int? FinalIdade { get; init; }
        public int pagInicial { get; init; } = 0;
        public int pagFinal { get; init; } = 10;

    }
}
