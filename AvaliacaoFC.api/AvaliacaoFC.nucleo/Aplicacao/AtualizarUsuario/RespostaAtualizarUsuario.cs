namespace AvaliacaoFC.Nucleo.Aplicacao.AtualizarUsuario
{
    public class RespostaAtualizarUsuario : RespostaBase
    {
        public RespostaAtualizarUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaAtualizarUsuario Invalido(string erros)
        {
            return new RespostaAtualizarUsuario(false, erros);
        }

        internal static RespostaAtualizarUsuario Sucesso()
        {
            return new RespostaAtualizarUsuario(true, string.Empty);
        }
    }
}
