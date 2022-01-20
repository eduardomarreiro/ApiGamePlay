    using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Data.Repositories
{
    public class Repository <T> : IRepository <T> where T : Entidade
    {
        public GamePlayContext _context;

        public Repository(GamePlayContext context)
        {
            _context = context;
        }

        public void Adicionar(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(T newEntity)
        {
            _context.Set<T>().Update(newEntity);
            _context.SaveChanges();
        }

        public void Deletar(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T RetornarPorId(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual List<T> RetornarTodos()
        {    
            return _context.Set<T>().ToList();
        }
    }
}
