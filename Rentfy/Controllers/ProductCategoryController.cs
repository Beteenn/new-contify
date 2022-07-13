using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentfy.Application.DTO;
using Rentfy.Application.Interfaces;
using Rentfy.Application.ViewModels;
using System.Threading.Tasks;

namespace Rentfy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : BaseApiController
    {
        private readonly IProductCategoryAppService _productCategoryAppService;

        public ProductCategoryController(IProductCategoryAppService productCategoryAppService)
        {
            _productCategoryAppService = productCategoryAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductCategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<IActionResult> GetProductCategory(long id)
        {
            var result = await _productCategoryAppService.GetProductCategoryById(id);

            return ResultRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductCategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProductCategory(ProductCategoryDto categoryDto)
        {
            var result = await _productCategoryAppService.UpdateProductCategory(categoryDto);

            return ResultRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductCategoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProductCategory(ProductCategoryDto categoryDto)
        {
            var result = await _productCategoryAppService.CreateProductCategory(categoryDto);

            return ResultRequest(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProductCategory(long id)
        {
            var result = await _productCategoryAppService.DeleteProductCategoryById(id);

            return ResultRequest(result);
        }
    }
}
