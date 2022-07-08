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

        public async Task<DomainResult<PhysicalPerson>> CreatePhysicalPerson(PhysicalPerson person)
        {
            await _physicalPersonRepository.AddPerson(person);
            await _physicalPersonRepository.UnitOfWork.CommitAsync();

            return new DomainResult<PhysicalPerson>(person);
        }
    }
}
