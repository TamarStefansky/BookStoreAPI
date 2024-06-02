using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Store.Core.Entities.Type;

namespace Store.Core.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public double Price { get; set; }
        public Type Type { get; set; }
        //public List<BranchDto> Branches { get; set; }

    }
}
