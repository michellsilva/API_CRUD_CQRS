namespace AvaliacaoFC.Nucleo.Aplicacao.InativarUsuario
{
    public class RespostaInativarUsuario : RespostaBase
    {
        public RespostaInativarUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaInativarUsuario Invalido(string erros)
        {
            return new RespostaInativarUsuario(false, erros);
        }

        internal static RespostaInativarUsuario Sucesso()
        {
            return new RespostaInativarUsuario(true, string.Empty);
        }
    }
}
