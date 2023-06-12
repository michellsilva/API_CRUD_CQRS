namespace AvaliacaoFC.Nucleo.Aplicacao.RecuperarSenhaUsuario
{
    public class RespostaRecuperarSenhaUsuario : RespostaBase
    {
        public RespostaRecuperarSenhaUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaRecuperarSenhaUsuario Invalido(string erros)
        {
            return new RespostaRecuperarSenhaUsuario(false, erros);
        }

        internal static RespostaRecuperarSenhaUsuario Sucesso()
        {
            return new RespostaRecuperarSenhaUsuario(true, string.Empty);
        }
    }
}
