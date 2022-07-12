using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Domain.Services
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly ILegalPersonRepository _legalPersonRepository;

        public LegalPersonService(ILegalPersonRepository legalPersonRepository)
        {
            _legalPersonRepository = legalPersonRepository ?? throw new ArgumentNullException(nameof(ILegalPersonRepository));
        }

        public async Task<DomainResult<LegalPerson>> GetById(long id)
        {
            var person = await _legalPersonRepository.GetById(id);

            return new DomainResult<LegalPerson>(person);
        }

        public async Task<DomainResult<LegalPerson>> Create(LegalPerson person)
        {
            await _legalPersonRepository.AddPerson(person);
            await _legalPersonRepository.UnitOfWork.CommitAsync();

            return new DomainResult<LegalPerson>(person);
        }

        public async Task<DomainResult<LegalPerson>> Update(long id, LegalPerson personUpdate)
        {
            var person = await _legalPersonRepository.GetById(id);

            if (person == null) return new DomainResult<LegalPerson>().AddErrorMessage("Pessoa não encontrada.");

            person.UpdateBasicInfo(personUpdate);

            await _legalPersonRepository.Update(person);
            await _legalPersonRepository.UnitOfWork.CommitAsync();

            return new DomainResult<LegalPerson>(person);
        }

        public async Task<DomainResult> DeleteById(long id)
        {
            var person = await _legalPersonRepository.GetById(id);

            if (person == null) return new DomainResult().AddErrorMessage("Pessoa não encontrada.");

            await _legalPersonRepository.Delete(person);
            await _legalPersonRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }
    }
}
