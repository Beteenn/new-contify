using Rentfy.Api.Controllers;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rentfy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObjetoTesteController : BaseApiController
    {
        private readonly ITesteAppService _testeAppService;

        public ObjetoTesteController(ITesteAppService testeAppService)
        {
            _testeAppService = testeAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ListObjects()
        {
            var result = await _testeAppService.ListObjects();

            return ResultRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _testeAppService.GetById(id);

            return ResultRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddObject(ObjetoTesteDto objetoDto)
        {
            var result = await _testeAppService.AddObject(objetoDto);

            return ResultRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateObject(ObjetoTesteDto objetoDto)
        {
            var result = await _testeAppService.UpdateObject(objetoDto);

            return ResultRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _testeAppService.DeleteById(id);

            return ResultRequest(result);
        }
    }
}
