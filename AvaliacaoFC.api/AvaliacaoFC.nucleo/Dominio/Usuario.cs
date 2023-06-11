using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Dominio
{
    public class Usuario : Entidade<int>
    {
        public Usuario(string nome, string login, string senha, string email, string telefone, int cpf, DateTime dataNascimento, string nomeMae)
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
        public int Cpf { get; init; }
        public DateTime DataNascimento { get; init; }
        public string NomeMae { get; init; }
        public Situacao Status { get; }
        public DateTime DataInclusao { get; }
        public DateTime? DataAlteracao { get; }

        public enum Situacao
        {
            INATIVADO,
            ATIVO,
            BLOQUEADO
        }
    }
}
