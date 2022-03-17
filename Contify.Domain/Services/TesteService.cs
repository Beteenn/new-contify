using Contify.Domain.Entities;
using Contify.Domain.Interfaces;
using Contify.Domain.InterfacesRepository;
using Contify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Domain.Services
{
    public class TesteService : ITesteService
    {
        private readonly IObjetoTesteRepository _objetoTesteRepository;

        public TesteService(IObjetoTesteRepository objetoTesteRepository)
        {
            _objetoTesteRepository = objetoTesteRepository ?? throw new ArgumentNullException(nameof(objetoTesteRepository));
        }

        public async Task<DomainResult<ObjetoTeste>> GetById(int id)
        {
            var objectTeste = await _objetoTesteRepository.GetById(id);

            return new DomainResult<ObjetoTeste>(objectTeste);
        }

        public async Task<DomainResult<IEnumerable<ObjetoTeste>>> ListObjects()
        {
            var listObjectTeste = await _objetoTesteRepository.ListObjects();

            return new DomainResult<IEnumerable<ObjetoTeste>>(listObjectTeste);
        }

        public async Task<DomainResult<ObjetoTeste>> AddObject(ObjetoTeste objeto)
        {
            await _objetoTesteRepository.AddObject(objeto);
            await _objetoTesteRepository.UnitOfWork.CommitAsync();

            return new DomainResult<ObjetoTeste>(objeto);
        }

        public async Task<DomainResult<ObjetoTeste>> UpdateObject(ObjetoTeste objeto)
        {
            var objetoRepo = await _objetoTesteRepository.GetById(objeto.Id);
            objetoRepo.Atualizar(objeto.Id, objeto.Nome);

            await _objetoTesteRepository.Update(objetoRepo);
            await _objetoTesteRepository.UnitOfWork.CommitAsync();

            return new DomainResult<ObjetoTeste>(objetoRepo);
        }

        public async Task DeleteObject(ObjetoTeste objeto)
        {
            await _objetoTesteRepository.DeleteObject(objeto);
            await _objetoTesteRepository.UnitOfWork.CommitAsync();
        }
    }
}
