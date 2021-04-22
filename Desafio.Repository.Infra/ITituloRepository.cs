using Desafio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Repository.Infra
{
    public interface ITituloRepository
    {
        Task<List<Titulo>> GetAllAsync();
        Task<long> Add(Titulo model);
    }
}
