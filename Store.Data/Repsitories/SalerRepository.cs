using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repsitories
{
    public class SalerRepository : ISalerRepository
    {
        private readonly DataContext _context;

        public SalerRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Saler> Get()
        {
            return _context.SalerList.Include(s => s.Branch);
        }
        public Saler Get(int id)
        {
            return _context.SalerList.ToList().Find(s => s.Id == id);
        }

        public Saler Post(Saler saler)
        {
            _context.SalerList.Add(saler);
            _context.SaveChanges();
            return saler;
        }

        public Saler Put(int id, Saler value)
        {
            Saler s = _context.SalerList.Find(id);
            if (s == null)
            {
                s = value;
                _context.SalerList.Add(s);
            }
            else
            {
                s.Name = value.Name;
                s.Salary = value.Salary;
            };
            _context.SaveChanges();
            return s;
        }
        public void Delete(int id)
        {
            Saler s = _context.SalerList.Find(id);
            _context.SalerList.Remove(s);
            _context.SaveChanges();
        }

        public void DeleteBySalary(int minSalary)
        {
            Saler s = _context.SalerList.ToList().Find(s => s.Salary == minSalary);
            _context.SalerList.Remove(s);
            _context.SaveChanges();
        }
    }
}
