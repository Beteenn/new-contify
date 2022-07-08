using AutoMapper;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Rentfy.Application.Services
{
    public class PhysicalPersonAppService : BaseAppService, IPhysicalPersonAppService
    {
        private readonly IPhysicalPersonService _physicalPersonService;

        public PhysicalPersonAppService(IPhysicalPersonService physicalPersonService, IMapper mapper) : base(mapper)
        {
            _physicalPersonService = physicalPersonService ?? throw new ArgumentNullException(nameof(physicalPersonService));
        }

        public async Task<Result<PhysicalPersonViewModel>> CreatePhysicalPerson(PhysicalPersonDto personDto)
        {
            var person = new PhysicalPerson(personDto.Name, personDto.Email, personDto.LastName,
                personDto.BirthDate, personDto.Document);

            var personUpdated = await _physicalPersonService.CreatePhysicalPerson(person);

            return Mapper.Map<Result<PhysicalPersonViewModel>>(personUpdated);
        }
    }
}
