using AutoMapper;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.SeedWork;
using Rentfy.Application.ViewModels;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Application.Services
{
    public class LegalPersonAppService : BaseAppService, ILegalPersonAppService
    {
        private readonly ILegalPersonService _legalPersonService;

        public LegalPersonAppService(ILegalPersonService legalPersonService, IMapper mapper) : base(mapper)
        {
            _legalPersonService = legalPersonService ?? throw new ArgumentNullException(nameof(legalPersonService));
        }

        public async Task<Result<LegalPersonViewModel>> GetLegalPersonById(long id)
        {
            var personResult = await _legalPersonService.GetById(id);

            return Mapper.Map<Result<LegalPersonViewModel>>(personResult);
        }

        public async Task<Result<LegalPersonViewModel>> CreateLegalPerson(LegalPersonDto personDto)
        {
            var person = new LegalPerson(personDto.Name, personDto.Email, personDto.Document, personDto.FantasyName);

            var personResult = await _legalPersonService.Create(person);

            return Mapper.Map<Result<LegalPersonViewModel>>(personResult);
        }

        public async Task<Result<LegalPersonViewModel>> UpdateLegalPerson(LegalPersonDto personDto)
        {
            var personUpdate = new LegalPerson(personDto.Name, personDto.Email, personDto.Document, personDto.FantasyName);

            var personResult = await _legalPersonService.Update(personDto.Id, personUpdate);

            return Mapper.Map<Result<LegalPersonViewModel>>(personResult);
        }

        public async Task<Result> DeleteLegalPersonById(long id)
        {
            var result = await _legalPersonService.DeleteById(id);

            return Mapper.Map<Result>(result);
        }
    }
}
