using CheckCenter.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace CheckCenter.ApplicationInterface.Functional
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/checktypes")]
    public class FunctionalTypeController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;

        public FunctionalTypeController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpPost]
        public ActionResult CreateType([FromBody] CheckType type)
        {
            var id = _typeRepository.CreateType(type);
            if (id > 0) return Ok(new { id });
            return new UnsupportedMediaTypeResult();
        }
    }
}
