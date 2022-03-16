using AutoMapper;
using Contify.Application.ViewModels;
using Contify.Domain.Entities;

namespace Contify.Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<ObjetoTeste, ObjetoTesteViewModel>()
                .ReverseMap();
        }

    }
}
