using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Infra.Servicos
{
    public interface IGeradorTemplate
    {
        string GerarTemplate(IEnumerable<string> valores, string nomeTemplate);
    }
}
