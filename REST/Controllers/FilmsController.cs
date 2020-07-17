using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrjWebApi01.Models;
using PrjWebApi01.Models.Repository;
using PrjWebApi01.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace PrjWebApi01.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class FilmsController : ControllerBase
    {
        private readonly IDataRepository<Films, FilmsDTO> _dataRepository;

        public FilmsController(IDataRepository<Films, FilmsDTO> pDataRepository)
        {
            _dataRepository = pDataRepository;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Films> Get()
        {
            var films = _dataRepository.GetAll();
            return films;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            var films = _dataRepository.Get(id);
            if (films != null)
            {
                return Ok(films);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost(Name = "Add")]
        public IActionResult Post([FromBody] films films)
        {
            if (films is null)
            {
                return BadRequest("Films is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(films);
            return CreatedAtRoute("GetById", new { Id = films.IdFilms }, null);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Films films)
        {
            if (films == null)
            {
                return BadRequest("Films is null.");
            }

            var filmsToUpdate = _dataRepository.Get(id);
            if (filmsToUpdate == null)
            {
                return NotFound("couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(filmsToUpdate, films);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotFound("no delete");
        }
    }
}