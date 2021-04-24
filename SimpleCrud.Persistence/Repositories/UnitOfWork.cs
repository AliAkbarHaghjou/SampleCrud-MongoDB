using SimpleCrud.Application.Context;
using SimpleCrud.Application.Repositories;
using SimpleCrud.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var changesCount = await _context.SaveChanges();
            return changesCount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
