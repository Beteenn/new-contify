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
    public class StoreController : BaseApiController
    {
        private readonly IStoreAppService _storeAppService;

        public StoreController(IStoreAppService storeAppService)
        {
            _storeAppService = storeAppService ?? throw new ArgumentNullException(nameof(storeAppService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(StoreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> GetStore(long id)
        {
            var result = await _storeAppService.GetStoreById(id);

            return ResultRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(StoreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStore(StoreDto storeDto)
        {
            var result = await _storeAppService.UpdateStore(storeDto);

            return ResultRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(StoreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStore(StoreDto storeDto)
        {
            var result = await _storeAppService.CreateStore(storeDto);

            return ResultRequest(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteStore(long id)
        {
            var result = await _storeAppService.DeleteStoreById(id);

            return ResultRequest(result);
        }
    }
}
