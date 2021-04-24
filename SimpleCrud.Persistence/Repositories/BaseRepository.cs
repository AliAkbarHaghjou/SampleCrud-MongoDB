using MongoDB.Bson;
using MongoDB.Driver;
using ServiceStack;
using SimpleCrud.Application.Context;
using SimpleCrud.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IApplicationDbContext Context;
        protected IMongoCollection<TEntity> entities;

        public BaseRepository(IApplicationDbContext context)
        {
            this.Context = context;
            entities = context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var Result = await entities.FindAsync(Builders<TEntity>.Filter.Empty);
            return Result.ToList();
        }
        public virtual async Task<TEntity> GetById(string id)
        {
            var Result = await entities.FindAsync(Builders<TEntity>.Filter.Eq("_id", new ObjectId(id)));
            return Result.FirstOrDefault();
        }
        public virtual void Add(TEntity entity)
        {
            Context.AddCommand(() => entities.InsertOneAsync(entity));
        }

        public virtual void Update(TEntity entity)
        {
            Context.AddCommand(() => entities.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity));
        }

        public virtual void Remove(string id)
        {
            Context.AddCommand(() => entities.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", new ObjectId(id))));
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
