using AutoMapper;
using Confitec.Api.ViewModels;
using Confitec.Domain.Entities;

namespace Confitec.Api.AutoMapper
{
    public class MapperBindingProfile : Profile
    {
        public MapperBindingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
        }
    }
}
