using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Dominio
{
    public abstract class Entidade<T>
    {
        public T? Id { get; init; }
    }
}
