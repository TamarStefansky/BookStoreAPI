using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.DTOs
{
    public class SalerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int BranchId { get; set; }
        public BranchDto Branch { get; set; }

    }
}
