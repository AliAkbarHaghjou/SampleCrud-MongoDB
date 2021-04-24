using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SimpleCrud.Application.Context;
using SimpleCrud.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Persistence.Context
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoClient MongoClient { get; set; }
        private IMongoDatabase Datatbase { get; set; }
        public IClientSessionHandle session { get; set; }
        private IConfiguration _configuration;
        private readonly List<Func<Task>> _commands;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _commands = new List<Func<Task>>();
        }
        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            ConfigureMongo();
            return Datatbase.GetCollection<TEntity>(name);
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (session = await MongoClient.StartSessionAsync())
            {
                session.StartTransaction();
                var commnadTasks = _commands.Select(c => c());
                await Task.WhenAll(commnadTasks);
                await session.CommitTransactionAsync();
            }
            return _commands.Count;
        }

        public void Dispose()
        {
            session?.Dispose();
        }

        public void ConfigureMongo()
        {
            if (MongoClient != null)
            {
                return;
            }
            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);
            Datatbase = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
        }
    }
}
