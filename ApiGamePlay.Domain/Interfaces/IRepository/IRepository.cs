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
        public void Adicionar(T entity);
        public T RetornarPorId(int id);
        public List<T> RetornarTodos();
        public void Atualizar(T newEntity);
        public void Deletar(T entity);
    }
}
