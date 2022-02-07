    using ApiGamePlay.Data.Context;
using ApiGamePlay.Domain.Interfaces;
using ApiGamePlay.Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<T> AdicionarAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Atualizar(T newEntity)
        {
            //_context.Entry(newEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Set<T>().Attach(newEntity);
            _context.SaveChanges();
        }

        public async Task<T> AtualizarAsync(T newEntity)
        {
            _context.Set<T>().Attach(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }

        public void Deletar(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeletarAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public T RetornarPorId(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> RetornarPorIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual List<T> RetornarTodos()
        {    
            return _context.Set<T>().ToList();
        }

        public virtual async Task<List<T>> RetornarTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
