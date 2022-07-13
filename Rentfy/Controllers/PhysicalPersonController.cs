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
    public class PhysicalPersonController : BaseApiController
    {
        private readonly IPhysicalPersonAppService _physicalPersonAppService;

        public PhysicalPersonController(IPhysicalPersonAppService physicalPersonAppService)
        {
            _physicalPersonAppService = physicalPersonAppService ?? throw new ArgumentNullException(nameof(physicalPersonAppService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PhysicalPersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> GetPhysicalPerson(long id)
        {
            var result = await _physicalPersonAppService.GetPhysicalPerson(id);

            return ResultRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PhysicalPersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePhysicalPerson(PhysicalPersonDto personDto)
        {
            var result = await _physicalPersonAppService.UpdatePhysicalPerson(personDto);

            return ResultRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhysicalPersonViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePhysicalPerson(PhysicalPersonDto personDto)
        {
            var result = await _physicalPersonAppService.CreatePhysicalPerson(personDto);

            return ResultRequest(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePhysicalPerson(long id)
        {
            var result = await _physicalPersonAppService.DeletePhysicalPersonById(id);

            return ResultRequest(result);
        }
    }
}
