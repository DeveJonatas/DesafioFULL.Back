using AutoMapper;
using Desafio.API.UoWs;
using Desafio.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitulosController : BaseController<TituloUoW>
    {

        public TitulosController(TituloUoW uow, IMapper mapper) : base(mapper, uow)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TituloResponse>>> GetTitulos()
        {
            var list = await _uow.TituloBLL.GetAllAsync();

            return Ok(_mapper.Map<List<TituloResponse>>(list));
        }

        [HttpPost]
        public async Task<ActionResult<TituloResponse>> PostTitulo(TituloRequest titulo)
        {
            var id = await _uow.TituloBLL.AddAsync(titulo);
            await _uow.SaveChangesAsync();

            return Ok(id);
        }
    }
}
