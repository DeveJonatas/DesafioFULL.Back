using Desafio.BLL.Infra;
using Desafio.Repository;

namespace Desafio.API.UoWs
{
    public class TituloUoW : BaseUoW
    {
        public ITituloBLL TituloBLL { get; private set; }

        public TituloUoW(DesafioDbContext dbContext, ITituloBLL tituloBLL) : base(dbContext)
        {
            TituloBLL = tituloBLL;
        }
    }
}
