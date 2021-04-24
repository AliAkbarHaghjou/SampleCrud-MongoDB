using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Application.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(string id);
        void Dispose();
    }
}
