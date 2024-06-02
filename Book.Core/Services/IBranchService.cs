using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services
{
    public interface IBranchService
    {
        IEnumerable<Branch> Get();
        Branch Get(int id);
        Branch Post(Branch branch);
        Branch Put(int id, Branch value);
        void Delete(int id);
        void putByCity(string city, int toAdd);
    }
}
