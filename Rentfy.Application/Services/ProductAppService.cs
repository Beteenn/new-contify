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
    public class ProductAppService : BaseAppService, IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService, IMapper mapper) : base(mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<Result<ProductViewModel>> GetProductById(long id)
        {
            var productResult = await _productService.GetById(id);

            return Mapper.Map<Result<ProductViewModel>>(productResult);
        }

        public async Task<Result<ProductViewModel>> CreateProduct(ProductDto productDto)
        {
            var productUpdate = new Product(productDto.Name, productDto.Description, productDto.Amount, productDto.HourValue, productDto.CategoryId);

            var personResult = await _productService.Create(productUpdate);

            return Mapper.Map<Result<ProductViewModel>>(personResult);
        }

        public async Task<Result<ProductViewModel>> UpdateProduct(ProductDto productDto)
        {
            var productUpdate = new Product(productDto.Name, productDto.Description, productDto.Amount, productDto.HourValue, productDto.CategoryId);

            var personResult = await _productService.Update(productDto.Id, productUpdate);

            return Mapper.Map<Result<ProductViewModel>>(personResult);
        }

        public async Task<Result> DeleteProductById(long id)
        {
            var result = await _productService.DeleteById(id);

            return Mapper.Map<Result>(result);
        }
    }
}
