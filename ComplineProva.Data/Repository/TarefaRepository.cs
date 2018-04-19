using ComplineProva.Data.Context;
using ComplineProva.Domain;
using ComplineProva.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace ComplineProva.Data.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private ComplineDataContext _context;

        public TarefaRepository(ComplineDataContext context)
        {
            this._context = context;
        }

        public void Add(Tarefa entity)
        {
            _context.Tarefas.Add(entity);
        }

        public void Delete(Tarefa entity)
        {
            _context.Tarefas.Remove(entity);
        }

        public void Delete(int id)
        {
            _context.Tarefas.Remove(GetSingle(id));
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(Tarefa entity)
        {
            _context.Tarefas.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<Tarefa> FindBy(Expression<Func<Tarefa, bool>> predicate)
        {
            IQueryable<Tarefa> query = _context.Set<Tarefa>().Where(predicate);
            return query.ToList();
        }

        public IList<Tarefa> GetAll()
        {
            var tarefas = _context.Tarefas.AsNoTracking().ToList();
            return tarefas;
        }

        public Tarefa GetSingle(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(x => x.Id == id);
            return tarefa;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
