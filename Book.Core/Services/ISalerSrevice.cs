using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services
{
    public interface ISalerSrevice
    {
        IEnumerable<Saler> Get();
        Saler Get(int id);
        Saler Post(Saler saler);
        Saler Put(int id, Saler value);
        void Delete(int id);
        void DeleteBySalary(int minSalary);
    }
}
