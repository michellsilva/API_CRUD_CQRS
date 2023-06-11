using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario
{
    public class RespostaCadastrarUsuario : RespostaBase
    {
        public RespostaCadastrarUsuario(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }

        internal static RespostaCadastrarUsuario Invalido(string erros)
        {
            return new RespostaCadastrarUsuario(false, erros);
        }

        internal static RespostaCadastrarUsuario Sucesso()
        {
            return new RespostaCadastrarUsuario(true, string.Empty);
        }
    }
}
