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
    public class BranchController : ControllerBase
    {
        

        private readonly IBranchService _branchServise;
        private readonly IMapper _mapper;
        public BranchController(IBranchService branchServise, IMapper mapper)
        {
            _branchServise = branchServise;
            _mapper = mapper;
        }

        // GET: api/<BranchController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _branchServise.Get();
            var listDto = _mapper.Map<IEnumerable<BranchDto>>(list);
            return Ok(listDto);
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var branch = _branchServise.Get(id);
            var branchDto = _mapper.Map<BranchDto>(branch);
            return Ok(branchDto);
        }

        // POST api/<BranchController>
        [HttpPost]
        public ActionResult Post([FromBody] BranchPostModel value)
        {
            var branch = _mapper.Map<Branch>(value);
            _branchServise.Post(branch);
            var branchDto = _mapper.Map<BranchDto>(branch);
            return Ok(branchDto);
        }

        // PUT api/<BranchController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BranchPostModel value)
        {
            var existBranch = _branchServise.Get(id);
            if (existBranch is null)
                return NotFound();
            _mapper.Map(value, existBranch);
            _branchServise.Put(id, existBranch);
            return Ok(_mapper.Map<BookDto>(existBranch));
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var branch = _branchServise.Get(id);
            if (branch is null)
            {
                return NotFound();
            }
            _branchServise.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public void putByCity(string city, int toAdd)
        {
         _branchServise.putByCity(city, toAdd);
        }
    }
}
