using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Rentfy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalPersonController : BaseApiController
    {
        private readonly ILegalPersonAppService _legalPersonAppService;

        public LegalPersonController(ILegalPersonAppService legalPersonAppService)
        {
            _legalPersonAppService = legalPersonAppService ?? throw new ArgumentNullException(nameof(legalPersonAppService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(LegalPersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> GetPhysicalPerson(long id)
        {
            var result = await _legalPersonAppService.GetLegalPersonById(id);

            return ResultRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(LegalPersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePhysicalPerson(LegalPersonDto personDto)
        {
            var result = await _legalPersonAppService.UpdateLegalPerson(personDto);

            return ResultRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LegalPersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePhysicalPerson(LegalPersonDto personDto)
        {
            var result = await _legalPersonAppService.CreateLegalPerson(personDto);

            return ResultRequest(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePhysicalPerson(long id)
        {
            var result = await _legalPersonAppService.DeleteLegalPersonById(id);

            return ResultRequest(result);
        }
    }
}
