using Desafio.Repository;
using System;
using System.Threading.Tasks;

namespace Desafio.API.UoWs
{
    public abstract class BaseUoW : IDisposable
    {
        protected DesafioDbContext _dbContext;

        public BaseUoW(DesafioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
