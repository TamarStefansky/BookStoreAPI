using Store.Core.Entities;
using Store.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Store.Data.Repsitories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> Get()
        {
            return _context.BookList;
        }

        public Book Get(int id)
        {
            return _context.BookList.ToList().Find(b => b.Id == id);
        }

        public List<Book> GetByType(Core.Entities.Type type)
        {
            return _context.BookList.Where(b => b.Type == type).ToList();
        }

        public void Delete(int id)
        {
            Book b = _context.BookList.Find(id);
            _context.BookList.Remove(b);
            _context.SaveChanges();
        }

        public Book Post(Book book)
        {
            _context.BookList.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Put(int id, Book value)
        {
            Book b = _context.BookList.Find(id);
            if (b != null)
            {
                b.Writer = value.Writer;
                b.Price = value.Price;
                b.Title = value.Title;
                b.Type = value.Type;
            }
            else
            {
                b = value;
                _context.BookList.Add(value);
            }
            _context.SaveChanges();
            return b;
        }
    }
}
