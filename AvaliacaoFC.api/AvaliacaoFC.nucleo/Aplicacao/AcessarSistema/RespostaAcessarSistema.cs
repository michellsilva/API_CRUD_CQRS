namespace AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema
{
    public class RespostaAcessarSistema : RespostaBase
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public RespostaAcessarSistema(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaAcessarSistema Invalido(string erros)
        {
            return new RespostaAcessarSistema(false, erros);
        }

        internal static RespostaAcessarSistema Sucesso(long id, string nome)
        {
            RespostaAcessarSistema resposta = new(true, string.Empty);
            resposta.Id = id;
            resposta.Nome = nome;

            return resposta;
        }
    }
}
