using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Application.Context
{
    public interface IApplicationDbContext : IDisposable
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
        Task<int> SaveChanges();
        void AddCommand(Func<Task> func);
    }
}
