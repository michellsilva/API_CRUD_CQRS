using AvaliacaoFC.Nucleo.Dominio;

namespace AvaliacaoFC.Nucleo.Infra.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Contexto>, IRepositorioUsuario
    {
        public RepositorioUsuario(Contexto contexto) : base(contexto)
        {
        }

        public void AtualizarDados(Usuario usuario)
        {
            Atualizar(usuario);
            Contexto.SaveChanges();
        }

        public void AtualizarLista(IEnumerable<Usuario> usuarios)
        {
            Atualizar(usuarios);
            Contexto.SaveChanges();
        }

        public void Casdastrar(Usuario usuario)
        {
            Inserir(usuario);
            Contexto.SaveChanges();
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return Contexto.Usuarios.OrderBy(x => x.Id).ToList();
        }

        public Usuario? ObterPorId(long id)
        {
            return Obter<Usuario>(x => x.Id == id);
        }

        public bool UsuarioJaCadastrado(Usuario usuario)
        {
            return Listar<Usuario>(x =>
                    x.Cpf.Equals(usuario.Cpf) ||
                    x.Login.Equals(usuario.Login) ||
                    x.Email.Equals(usuario.Email)).Any();
        }
    }
}
