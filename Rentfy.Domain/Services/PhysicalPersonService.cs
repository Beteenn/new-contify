using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Rentfy.Domain.Services
{
    public class PhysicalPersonService : IPhysicalPersonService
    {
        private readonly IPhysicalPersonRepository _physicalPersonRepository;

        public PhysicalPersonService(IPhysicalPersonRepository physicalPersonRepository)
        {
            _physicalPersonRepository = physicalPersonRepository ?? throw new ArgumentNullException(nameof(physicalPersonRepository));
        }

        public async Task<DomainResult<PhysicalPerson>> GetById(long id)
        {
            var person = await _physicalPersonRepository.GetById(id);

            return new DomainResult<PhysicalPerson>(person);
        }

        public async Task<DomainResult<PhysicalPerson>> CreatePhysicalPerson(PhysicalPerson person)
        {
            await _physicalPersonRepository.AddPerson(person);
            await _physicalPersonRepository.UnitOfWork.CommitAsync();

            return new DomainResult<PhysicalPerson>(person);
        }

        public async Task<DomainResult<PhysicalPerson>> Update(long id, PhysicalPerson personUpdate)
        {
            var person = await _physicalPersonRepository.GetById(id);

            if (person == null) return new DomainResult<PhysicalPerson>().AddErrorMessage("Pessoa não encontrada.");

            person.UpdateBasicInfo(personUpdate);

            await _physicalPersonRepository.Update(person);
            await _physicalPersonRepository.UnitOfWork.CommitAsync();

            return new DomainResult<PhysicalPerson>(person);
        }

        public async Task<DomainResult> DeleteById(long id)
        {
            var person = await _physicalPersonRepository.GetById(id);

            if (person == null) return new DomainResult().AddErrorMessage("Pessoa não encontrada.");

            await _physicalPersonRepository.Delete(person);
            await _physicalPersonRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }
    }
}
