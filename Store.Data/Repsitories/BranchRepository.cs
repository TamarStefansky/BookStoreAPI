using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repsitories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _context;

        public BranchRepository(DataContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            Branch b = _context.BranchList.Find(id);
            _context.BranchList.Remove(b);
            _context.SaveChanges();
        }

        public IEnumerable<Branch> Get()
        {
            return _context.BranchList.Include(s=>s.Salers);
        }

        public Branch Get(int id)
        {
            return _context.BranchList.ToList().Find(b => b.id == id);
        }

        public Branch Post(Branch branch)
        {
            _context.BranchList.Add(branch);
            _context.SaveChanges();
            return branch;
        }

        public Branch Put(int id, Branch value)
        {
            Branch b = _context.BranchList.Find(id);
            if (b == null)
            {
                b = value;
                _context.BranchList.Add(b);
            }
            else
            {
                b.Street = value.Street;
                b.City = value.City;
                b.CountOfSalers = value.CountOfSalers;
            }
            _context.SaveChanges();
            return b;
        }

        public void putByCity(string city, int toAdd)
        {
            foreach (Branch b in _context.BranchList)
            {
                if (b.City == city)
                {
                    b.CountOfSalers += toAdd;
                }
            }
            _context.SaveChanges();
        }
    }
}
