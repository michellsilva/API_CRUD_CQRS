using AvaliacaoFC.Nucleo.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Infra.Repositorios
{
    public interface IRepositorioUsuario
    {
        void Casdastrar(Usuario usuario);
        Usuario? ObterPorId(long id);
        IEnumerable<Usuario> ListarTodos();
    }
}
