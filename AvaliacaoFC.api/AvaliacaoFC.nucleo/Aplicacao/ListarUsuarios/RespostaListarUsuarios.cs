using AvaliacaoFC.Nucleo.Dominio;

namespace AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios
{
    public class RespostaListarUsuarios : RespostaBase
    {
        public List<RespostaUsuario> Usuarios { get; set; } = new();

        public RespostaListarUsuarios(bool sucesso, string mensagem) : base(sucesso, mensagem)
        {
        }
        internal static RespostaListarUsuarios Sucesso(IEnumerable<Usuario> usuarios)
        {
            RespostaListarUsuarios resposta = new(true, string.Empty);

            if (usuarios != null)
            {
                foreach (var item in usuarios)
                {
                    resposta.Usuarios.Add(new()
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Login = item.Login,
                        Email = item.Email,
                        Telefone = item.Telefone,
                        Cpf = item.Cpf,
                        DataNascimento = item.DataNascimento,
                        NomeMae = item.NomeMae,
                        Status = (long)item.Status
                    });
                }
            }

            return resposta;
        }
        public class RespostaUsuario
        {
            public long Id { get; set; }
            public string Nome { get; init; }
            public string Login { get; init; }
            public string Email { get; init; }
            public string Telefone { get; init; }
            public string Cpf { get; init; }
            public DateTime DataNascimento { get; init; }
            public string NomeMae { get; init; }
            public long Status { get; init; }
        }
    }
}
