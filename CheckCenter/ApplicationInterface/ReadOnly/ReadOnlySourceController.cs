using CheckCenter.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckCenter.ApplicationInterface.ReadOnly
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/sources")]
    public class ReadOnlySourceController : ControllerBase {
        private readonly ISourceRepository _sourceRepository;

        public ReadOnlySourceController(ISourceRepository sourceRepository) {
            _sourceRepository = sourceRepository;
        }

        [HttpGet]
        public ActionResult GetAllSources() {
            return Ok(_sourceRepository.GetAllSources());
        }

        [HttpGet("{id}")]
        public ActionResult GetSource(int id) {
            var source = _sourceRepository.GetSource(id);
            if (source.Id > 0) return Ok(source);
            return NotFound();
        }
    }
}
