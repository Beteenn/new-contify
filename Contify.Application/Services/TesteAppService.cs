using AutoMapper;
using Contify.Application.DTO;
using Contify.Application.Interfaces;
using Contify.Application.SeedWork;
using Contify.Application.ViewModels;
using Contify.Domain.Entities;
using Contify.Domain.Interfaces;

namespace Contify.Application.Services
{
    public class TesteAppService : BaseAppService, ITesteAppService
    {
        private readonly ITesteService _testeService;
        public TesteAppService(ITesteService testeService, IMapper mapper) : base(mapper)
        {
            _testeService = testeService;
        }

        public Result<ObjetoTesteViewModel> Teste(ObjetoTesteDto objetoDto)
        {
            var objeto = new ObjetoTeste(objetoDto.Id, objetoDto.Nome);

            var objetoAtualizado = _testeService.AtualizarObjeto(objeto);

            return Mapper.Map<Result<ObjetoTesteViewModel>>(objetoAtualizado);
        }
    }
}
