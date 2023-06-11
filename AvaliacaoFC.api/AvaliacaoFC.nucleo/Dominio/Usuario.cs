namespace AvaliacaoFC.Nucleo.Dominio
{
    public class Usuario : Entidade<int>
    {
        public Usuario(string nome, string login, string senha, string email, string telefone, string cpf, DateTime dataNascimento, string nomeMae)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            NomeMae = nomeMae;
            Status = Situacao.ATIVO;
            DataInclusao = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string NomeMae { get; private set; }
        public Situacao Status { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        public enum Situacao
        {
            INATIVO,
            ATIVO,
            BLOQUEADO
        }

        public void AtualizarDados(string nome, string login, string email, string telefone, string cpf, DateTime dataNascimento, string nomeMae, Situacao status)
        {
            Nome = nome;
            Login = login;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            NomeMae = nomeMae;
            Status = status;
            DataAlteracao = DateTime.Now;
        }

        public void Inativar()
        {
            Status = Situacao.INATIVO;
            DataAlteracao = DateTime.Now;
        }

        public void Bloquear()
        {
            Status = Situacao.BLOQUEADO;
            DataAlteracao = DateTime.Now;
        }

        public void Ativar()
        {
            Status = Situacao.ATIVO;
            DataAlteracao = DateTime.Now;
        }
    }
}
