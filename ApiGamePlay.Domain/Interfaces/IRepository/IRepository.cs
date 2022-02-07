using ApiGamePlay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGamePlay.Domain.Interfaces
{
    public interface IRepository <T> where T : Entidade
    {
        void Adicionar(T entity);
        Task<T> AdicionarAsync(T entity);
        T RetornarPorId(int id);
        Task<T> RetornarPorIdAsync(int id);
        List<T> RetornarTodos();
        Task<List<T>> RetornarTodosAsync();
        void Atualizar(T newEntity);
        Task<T> AtualizarAsync(T newEntity);
        void Deletar(T entity);
        Task DeletarAsync(T newEntity);
    }
}
