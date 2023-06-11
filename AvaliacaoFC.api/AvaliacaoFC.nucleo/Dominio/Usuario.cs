using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Nome { get; init; }
        public string Login { get; init; }
        public string Senha { get; init; }
        public string Email { get; init; }
        public string Telefone { get; init; }
        public string Cpf { get; init; }
        public DateTime DataNascimento { get; init; }
        public string NomeMae { get; init; }
        public Situacao Status { get; init; }
        public DateTime DataInclusao { get; init; }
        public DateTime? DataAlteracao { get; init; }

        public enum Situacao
        {
            INATIVADO,
            ATIVO,
            BLOQUEADO
        }
    }
}
