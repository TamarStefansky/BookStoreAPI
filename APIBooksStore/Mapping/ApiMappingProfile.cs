using APIBooksStore.Models;
using AutoMapper;
using Store.Core.Entities;

namespace APIBooksStore.Mapping
{
    public class ApiMappingProfile :Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<BookPostModel, Book>();
            CreateMap<BranchPostModel, Branch>();
            CreateMap<SalerPostModel, Saler>();
        }
    }
}
