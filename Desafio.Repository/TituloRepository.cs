using Desafio.Models;
using Desafio.Repository.Infra;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Repository
{
    public class TituloRepository : BaseRepository, ITituloRepository
    {
        public TituloRepository(DesafioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Titulo>> GetAllAsync()
        {
            return await _dbContext.TitulosQuery.Include(x => x.Parcelas).ToListAsync();
        }

        public async Task<long> Add(Titulo model)
        {
            var query = await _dbContext.Titulos.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return query.Entity.Id;
        }

    }
}
