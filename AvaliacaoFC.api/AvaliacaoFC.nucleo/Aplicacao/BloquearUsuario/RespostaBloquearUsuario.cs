namespace AvaliacaoFC.Nucleo.Aplicacao.BloquearUsuario
{
    public class RespostaBloquearUsuario : RespostaBase
    {
        public RespostaBloquearUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaBloquearUsuario Invalido(string erros)
        {
            return new RespostaBloquearUsuario(false, erros);
        }

        internal static RespostaBloquearUsuario Sucesso()
        {
            return new RespostaBloquearUsuario(true, string.Empty);
        }
    }
}
