using AutoMapper;
using Desafio.API.UoWs;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    public class BaseController<T> : Controller where T : BaseUoW
    {
        public readonly IMapper _mapper;
        public readonly T _uow;

        public BaseController(IMapper mapper, T uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
                _uow.Dispose();
        }
    }
}
