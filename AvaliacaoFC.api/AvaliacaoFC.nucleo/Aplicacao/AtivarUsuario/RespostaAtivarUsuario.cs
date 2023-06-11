namespace AvaliacaoFC.Nucleo.Aplicacao.AtivarUsuario
{
    public class RespostaAtivarUsuario : RespostaBase
    {
        public RespostaAtivarUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaAtivarUsuario Invalido(string erros)
        {
            return new RespostaAtivarUsuario(false, erros);
        }

        internal static RespostaAtivarUsuario Sucesso()
        {
            return new RespostaAtivarUsuario(true, string.Empty);
        }
    }
}
