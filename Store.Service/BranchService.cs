using Store.Core.Entities;
using Store.Core.Repositories;
using Store.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public void Delete(int id)
        {
            _branchRepository.Delete(id);
        }

        public IEnumerable<Branch> Get()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            return _branchRepository.Get();
        }

        public Branch Get(int id)
        {
            return _branchRepository.Get(id);
        }

        public Branch Post(Branch branch)
        {
            return _branchRepository.Post(branch);
        }

        public Branch Put(int id, Branch value)
        {
           return _branchRepository.Put(id, value);
        }

        public void putByCity(string city, int toAdd)
        {
            _branchRepository.putByCity(city, toAdd);
        }

    }
}
