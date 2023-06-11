namespace AvaliacaoFC.Nucleo.Aplicacao.InativarTodosUsuario
{
    public class RespostaInativarTodosUsuario : RespostaBase
    {
        public RespostaInativarTodosUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaInativarTodosUsuario Invalido(string erros)
        {
            return new RespostaInativarTodosUsuario(false, erros);
        }

        internal static RespostaInativarTodosUsuario Sucesso()
        {
            return new RespostaInativarTodosUsuario(true, string.Empty);
        }
    }
}
