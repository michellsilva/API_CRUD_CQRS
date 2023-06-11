using AvaliacaoFC.Nucleo.Dominio;
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

        public void Casdastrar(Usuario usuario)
        {
            Inserir<Usuario>(usuario);
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return Contexto.Usuarios.ToList();
        }

        public Usuario? ObterPorId(long id)
        {
            return Obter<Usuario>(x => x.Id == id);
        }
    }
}
