using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoFC.Nucleo.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoFC.Nucleo.Infra.Repositorios
{
    public class RepositorioBase<TContexto> : IRepositorioBase where TContexto : DbContext
    {
        protected TContexto Contexto { get; private set; }

        public RepositorioBase(TContexto contexto)
        {
            Contexto = contexto;
        }

        #region Consulta

        protected IEnumerable<T> Listar<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Contexto.Set<T>().Where(predicate).AsNoTracking().ToList();
        }

        protected T? Obter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Contexto.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        #endregion Consulta

        #region Inserir

        protected void Inserir<T>(T entidade) where T : class
        {
            Contexto.Set<T>().Add(entidade);
        }

        protected void Inserir<T>(IEnumerable<T> entidades) where T : class
        {
            Contexto.Set<T>().AddRange(entidades);
        }

        #endregion Inserir

        #region Atualizar

        protected void Atualizar<T>(T entidade) where T : class
        {
            Contexto.Set<T>().Update(entidade);
        }

        protected void Atualizar<T>(IEnumerable<T> entidades) where T : class
        {
            Contexto.Set<T>().UpdateRange(entidades);
        }

        #endregion Atualizar

        #region Apagar

        protected void Excluir<T>(T entidade) where T : class
        {
            Contexto.Set<T>().Remove(entidade);
        }

        protected void Excluir<T>(IEnumerable<T> entidades) where T : class
        {
            Contexto.Set<T>().RemoveRange(entidades);
        }

        protected void Excluir<T>(Expression<Func<T, bool>> predicado) where T : class
        {
            Contexto.Set<T>().RemoveRange(Contexto.Set<T>().Where(predicado));
        }

        #endregion Apagar
    }
}
