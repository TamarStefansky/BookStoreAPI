using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Store.Core.Entities.Type;

namespace Store.Core.Services
{
    public interface IBookService
    {
        IEnumerable<Book> Get();
        Book Get(int id);
        Book Post(Book book);
        Book Put(int id, Book value);
        void Delete(int id);
        List<Book> GetByType(Type type);
    }
}
