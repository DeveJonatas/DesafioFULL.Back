namespace Desafio.Repository
{
    public class BaseRepository
    {
        public readonly DesafioDbContext _dbContext;

        public BaseRepository(DesafioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
