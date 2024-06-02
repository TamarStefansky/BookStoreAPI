using Store.Core.Entities;
using Store.Core.Repositories;
using Store.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Store.Core.Entities.Type;

namespace Store.Service
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public IEnumerable<Book> Get()
        {
            return _bookRepository.Get();
        }

        public Book Get(int id)
        {
            return _bookRepository.Get(id);
        }

        public List<Book> GetByType(Type type)
        {
            return _bookRepository.GetByType(type);
        }

        public Book Post(Book book)
        {
           return _bookRepository.Post(book);
        }

        public Book Put(int id, Book value)
        {
           return _bookRepository.Put(id, value);
        }

    }
}
