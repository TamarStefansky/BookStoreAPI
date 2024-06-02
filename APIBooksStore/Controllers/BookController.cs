using APIBooksStore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core.DTOs;
using Store.Core.Entities;
using Store.Core.Services;
using Type = Store.Core.Entities.Type;

namespace APIBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService,IMapper mapper)
        {
            _bookService = bookService;
            _mapper=mapper;
        }


 
        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _bookService.Get();
            var listDto = _mapper.Map<IEnumerable<BookDto>>(list);
            return Ok(_bookService.Get());
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] BookPostModel value)
        {
            var book=_mapper.Map<Book>(value);
           // var book = new Book { Title = value.Title ,Price=value.Price,Writer=value.Writer,Type = value.Type};
            _bookService.Post(book);
            var bookDto= _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BookPostModel value)
        {
         var existBook=_bookService.Get(id);
            if (existBook is null)
                return NotFound();
            _mapper.Map(value, existBook);
            _bookService.Put(id, existBook);  
            return Ok(_mapper.Map<BookDto>(existBook));
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _bookService.Get(id);
            if (book is null)
            {
                return NotFound();
            }
            _bookService.Delete(id);
            return NoContent();
        }

        [HttpGet("/type")]
        public IActionResult GetByType(Type type)
        {
            return Ok(_bookService.GetByType(type));
        }
    }
}
