using Contify.Application.DTO;
using Contify.Application.Interfaces;
using Contify.Application.ViewModels;
using Contify.Domain.Entities;
using Contify.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Application.Services
{
    public class TesteAppService : ITesteAppService
    {
        private readonly ITesteService _testeService;
        public TesteAppService(ITesteService testeService)
        {
            _testeService = testeService;
        }

        public ObjetoTesteViewModel Teste(ObjetoTesteDto objetoDto)
        {
            var objeto = new ObjetoTeste(objetoDto.Id, objetoDto.Nome);

            var objetoAtualizado = _testeService.AtualizarObjeto(objeto);

            return new ObjetoTesteViewModel() { Id = objetoAtualizado.Id, Nome = objetoAtualizado.Nome };
        }
    }
}
