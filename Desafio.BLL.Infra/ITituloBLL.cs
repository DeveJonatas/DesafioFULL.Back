using Desafio.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.BLL.Infra
{
    public interface ITituloBLL
    {
        Task<List<TituloResponse>> GetAllAsync();
        Task<long> AddAsync(TituloRequest entity);        
    }
}
