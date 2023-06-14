using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Infra.Servicos
{
    public interface IGeradorCriptografia
    {
        string Criptografar(string texto);
        string Descriptografar(string texto);
    }
}
