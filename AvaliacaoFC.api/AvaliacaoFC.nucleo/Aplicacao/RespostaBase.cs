namespace AvaliacaoFC.Nucleo.Aplicacao
{
    public class RespostaBase
    {
        public string Mensagem { get; init; }
        public bool Sucesso { get; init; }

        public RespostaBase(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}
