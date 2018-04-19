using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ComplineProva.Domain.Repository
{
    public interface ITarefaRepository : IDisposable
    {
        IList<Tarefa> GetAll();
        Tarefa GetSingle(int id);
        IList<Tarefa> FindBy(Expression<Func<Tarefa, bool>> predicate);
        void Add(Tarefa entity);
        void Delete(Tarefa entity);
        void Delete(int id);
        void Edit(Tarefa entity);
        void Save();
    }
}
