using AvaliacaoFC.Nucleo.Dominio;
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
    }
}
