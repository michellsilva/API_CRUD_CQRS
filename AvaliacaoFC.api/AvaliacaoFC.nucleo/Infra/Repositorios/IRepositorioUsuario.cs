using AvaliacaoFC.Nucleo.Dominio;
using System.Linq.Expressions;
using static AvaliacaoFC.Nucleo.Dominio.Usuario;

namespace AvaliacaoFC.Nucleo.Infra.Repositorios
{
    public interface IRepositorioUsuario
    {
        void Casdastrar(Usuario usuario);
        Usuario? ObterPorId(long id);
        IEnumerable<Usuario> ListarTodos();
        bool UsuarioJaCadastrado(Usuario usuario);
        void AtualizarDados(Usuario usuario);
        void AtualizarLista(IEnumerable<Usuario> usuarios);
        Usuario? ObterPorLoginESenha(string login, string senha);
        Usuario? ObterPorEmail(string email);
        IEnumerable<Usuario> Consultar(Expression<Func<Usuario, bool>> predicate);
    }
}
