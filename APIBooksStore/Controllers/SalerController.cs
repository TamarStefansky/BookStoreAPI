using APIBooksStore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Core.DTOs;
using Store.Core.Entities;
using Store.Core.Services;
using Store.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalerController : ControllerBase
    {
        
        private readonly ISalerSrevice _salerSrevice;
        private readonly IMapper _mapper;

        public SalerController(ISalerSrevice salerSrevice, IMapper mapper)
        {
            _salerSrevice = salerSrevice;
            _mapper = mapper;

        }



        // GET: api/<SalerController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _salerSrevice.Get();
            var listDto = _mapper.Map<IEnumerable<SalerDto>>(list);
            return Ok(listDto);
        }

        // GET api/<SalerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var saler = _salerSrevice.Get(id);
            var salerDto = _mapper.Map<SalerDto>(saler);
            return Ok(salerDto);
        }

        // POST api/<SalerController>
        [HttpPost]
        public ActionResult Post([FromBody] SalerPostModel value)
        {
            var saler = _mapper.Map<Saler>(value);
            _salerSrevice.Post(saler);
            var salerDto = _mapper.Map<SalerDto>(saler);
            return Ok(salerDto);
        }

        // PUT api/<SalerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SalerPostModel value)
        {
            //return Ok(_salerSrevice.Put(id, value));
            var existSaler = _salerSrevice.Get(id);
            if (existSaler is null)
                return NotFound();
            _mapper.Map(value, existSaler);
            _salerSrevice.Put(id, existSaler);
            return Ok(_mapper.Map<SalerDto>(existSaler));
        }

        // DELETE api/<SalerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var saler = _salerSrevice.Get(id);
            if (saler is null)
            {
                return NotFound();
            }
            _salerSrevice.Delete(id);
            return NoContent();
        }

        [HttpDelete]
        public void DeleteBySalary(int minSalary)
        {
            _salerSrevice.DeleteBySalary(minSalary);
        }
    }
}
