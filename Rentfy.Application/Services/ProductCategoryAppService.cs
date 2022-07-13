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
    public class ProductCategoryAppService : BaseAppService, IProductCategoryAppService
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryAppService(IProductCategoryService productCategoryService, IMapper mapper) : base(mapper)
        {
            _productCategoryService = productCategoryService ?? throw new ArgumentNullException(nameof(productCategoryService));
        }

        public async Task<Result<ProductCategoryViewModel>> GetProductCategoryById(long id)
        {
            var categoryResult = await _productCategoryService.GetById(id);

            return Mapper.Map<Result<ProductCategoryViewModel>>(categoryResult);
        }

        public async Task<Result<ProductCategoryViewModel>> CreateProductCategory(ProductCategoryDto categoryDto)
        {
            var category = new ProductCategory(categoryDto.Name);

            var categoryResult = await _productCategoryService.Create(category);

            return Mapper.Map<Result<ProductCategoryViewModel>>(categoryResult);
        }

        public async Task<Result<ProductCategoryViewModel>> UpdateProductCategory(ProductCategoryDto categoryDto)
        {
            var categoryUpdate = new ProductCategory(categoryDto.Name);

            var personResult = await _productCategoryService.Update(categoryDto.Id, categoryUpdate);

            return Mapper.Map<Result<ProductCategoryViewModel>>(personResult);
        }

        public async Task<Result> DeleteProductCategoryById(long id)
        {
            var result = await _productCategoryService.DeleteById(id);

            return Mapper.Map<Result>(result);
        }
    }
}
