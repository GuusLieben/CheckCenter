using CheckCenter.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace CheckCenter.ApplicationInterface.Functional
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/sources")]
    public class FunctionalSourceController : ControllerBase
    {
        private readonly ISourceRepository _sourceRepository;


        public FunctionalSourceController(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }

        [HttpPost]
        public ActionResult CreateSource([FromBody] Source source)
        {
            var id = _sourceRepository.CreateSource(source);
            if (id > 0) return Ok( new { id });
            return new UnsupportedMediaTypeResult();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSource([FromBody] Source source, int id)
        {
            source.Id = id;
            var result = _sourceRepository.UpdateSource(source);
            return Ok(new { result });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSource([FromBody] Source source, int id)
        {
            source.Id = id;
            var result = _sourceRepository.DeleteSource(source);
            return Ok(new { result });
        }
    }
}
