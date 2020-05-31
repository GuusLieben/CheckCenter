using CheckCenter.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace CheckCenter.ApplicationInterface.Functional
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/states")]
    public class FunctionalStateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;

        public FunctionalStateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpPost]
        public ActionResult CreateState([FromBody] State state)
        {
            var id = _stateRepository.CreateState(state);
            if (id > 0) return Ok(new { id });
            return new UnsupportedMediaTypeResult();
        }
    }
}
