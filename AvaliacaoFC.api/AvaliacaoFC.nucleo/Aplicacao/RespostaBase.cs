using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
