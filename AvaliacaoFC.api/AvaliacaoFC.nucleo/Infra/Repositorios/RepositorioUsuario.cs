using AvaliacaoFC.Nucleo.Dominio;
using System.Linq.Expressions;

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

        public Usuario? ObterPorLoginESenha(string login, string senha)
        {
            return Obter<Usuario>(x =>
                x.Login.Trim().ToLower() == login.Trim().ToLower() &&
                x.Senha == senha);
        }

        public bool UsuarioJaCadastrado(Usuario usuario)
        {
            return Listar<Usuario>(x =>
                    x.Cpf.Equals(usuario.Cpf) ||
                    x.Login.Trim().ToLower() == usuario.Login.Trim().ToLower() ||
                    x.Email.Trim().ToLower() == usuario.Email.Trim().ToLower()).Any();
        }

        public Usuario? ObterPorEmail(string email)
        {
            return Obter<Usuario>(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
        }

        public IEnumerable<Usuario> Consultar(Expression<Func<Usuario, bool>> predicate)
        {
            return Listar(predicate).ToList();
        }
    }
}
