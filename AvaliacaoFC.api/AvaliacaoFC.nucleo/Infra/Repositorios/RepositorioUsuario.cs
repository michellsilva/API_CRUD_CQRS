using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Infra.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Contexto>, IRepositorioUsuario
    {
        public RepositorioUsuario(Contexto contexto) : base(contexto)
        {
        }
    }
}
