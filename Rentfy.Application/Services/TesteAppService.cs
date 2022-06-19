using AutoMapper;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rentfy.Application.Services
{
    public class TesteAppService : BaseAppService, ITesteAppService
    {
        private readonly ITesteService _testeService;
        public TesteAppService(ITesteService testeService, IMapper mapper) : base(mapper)
        {
            _testeService = testeService;
        }

        public async Task<Result<ObjetoTesteViewModel>> AddObject(ObjetoTesteDto objetoDto)
        {
            var objeto = new ObjetoTeste(objetoDto.Id, objetoDto.Nome);

            var objetoAtualizado = await _testeService.AddObject(objeto);

            return Mapper.Map<Result<ObjetoTesteViewModel>>(objetoAtualizado);
        }

        public async Task<Result> DeleteById(int id)
        {
            var objeto = await _testeService.GetById(id);

            if (objeto.Data == null)
                return new Result();

            await _testeService.DeleteObject(objeto.Data);

            return new Result();
        }

        public async Task<Result<ObjetoTesteViewModel>> GetById(int id)
        {
            var objectTeste = await _testeService.GetById(id);

            return Mapper.Map<Result<ObjetoTesteViewModel>>(objectTeste);
        }

        public async Task<Result<IEnumerable<ObjetoTesteViewModel>>> ListObjects()
        {
            var listObjectTeste = await _testeService.ListObjects();

            return Mapper.Map<Result<IEnumerable<ObjetoTesteViewModel>>>(listObjectTeste);
        }

        public async Task<Result<ObjetoTesteViewModel>> UpdateObject(ObjetoTesteDto objetoDto)
        {
            var objeto = new ObjetoTeste(objetoDto.Id, objetoDto.Nome);

            var objetoAtualizado = await _testeService.UpdateObject(objeto);

            return Mapper.Map<Result<ObjetoTesteViewModel>>(objetoAtualizado);
        }
    }
}
