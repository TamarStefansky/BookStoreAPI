using AutoMapper;
using Store.Core.DTOs;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto,Book>().ReverseMap();
            CreateMap<SalerDto,Saler>().ReverseMap();
            CreateMap<BranchDto,Branch>().ReverseMap();
        }
    }
}
