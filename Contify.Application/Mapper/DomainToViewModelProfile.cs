using AutoMapper;
using Contify.Application.SeedWork;
using Contify.Application.ViewModels;
using Contify.Domain.Entities;
using Contify.Domain.SeedWork;

namespace Contify.Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap(typeof(DomainResult<>), typeof(Result<>));

            CreateMap<DomainResult, Result>()
                .ReverseMap();

            CreateMap<ObjetoTeste, ObjetoTesteViewModel>()
                .ReverseMap();
        }

    }
}
