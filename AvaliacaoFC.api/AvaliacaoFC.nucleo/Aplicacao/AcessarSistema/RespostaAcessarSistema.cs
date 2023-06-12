namespace AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema
{
    public class RespostaAcessarSistema : RespostaBase
    {
        public RespostaAcessarSistema(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaAcessarSistema Invalido(string erros)
        {
            return new RespostaAcessarSistema(false, erros);
        }

        internal static RespostaAcessarSistema Sucesso()
        {
            return new RespostaAcessarSistema(true, string.Empty);
        }
    }
}
