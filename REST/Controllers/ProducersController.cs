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
    public class ProducersController : ControllerBase
    {
        private readonly IDataRepository<Producers, ProducersDTO> _dataRepository;

        public ProducersController(IDataRepository<Producers, ProducersDTO> pDataRepository)
        {
            _dataRepository = pDataRepository; 
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Producers> Get(){
            var producers = _dataRepository.GetAll();
            return producers;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult Get(int id)
        {        
            var producer= _dataRepository.Get(id);
                if(producer != null){
                    return Ok(producer);
                }else{
                    return NotFound();
                }

        }

        [HttpPost(Name ="Add")]
        public IActionResult Post([FromBody] Producers producer)
        {
            if (producer is null)
            {
                return BadRequest("Producer is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(producer);
            return CreatedAtRoute("GetById", new { Id = producer.IdProducer }, null);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Producers producer)
        {
            if (producer == null)
            {
                return BadRequest("Producers is null.");
            }

            var producerToUpdate = _dataRepository.Get(id);
            if (producerToUpdate == null)
            {
                return NotFound("couldn't be found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Update(producerToUpdate, producer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NotFound("no delete");
        } 
    }
}