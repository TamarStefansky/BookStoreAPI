using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.DTOs
{
    public class BranchDto
    {
        public int id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int CountOfSalers { get; set; }
       // public List<BookDto> Books { get; set; }
    }
}
