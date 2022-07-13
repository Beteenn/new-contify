using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Rentfy.Domain.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository ?? throw new ArgumentNullException(nameof(productCategoryRepository));
        }

        public async Task<DomainResult<ProductCategory>> GetById(long id)
        {
            var category = await _productCategoryRepository.GetById(id);

            return new DomainResult<ProductCategory>(category);
        }

        public async Task<DomainResult<ProductCategory>> Create(ProductCategory category)
        {
            await _productCategoryRepository.Add(category);
            await _productCategoryRepository.UnitOfWork.CommitAsync();

            return new DomainResult<ProductCategory>(category);
        }

        public async Task<DomainResult<ProductCategory>> Update(long id, ProductCategory category)
        {
            var person = await _productCategoryRepository.GetById(id);

            if (person == null) return new DomainResult<ProductCategory>().AddErrorMessage("Categoria não encontrada.");

            person.UpdateName(category.Name);

            await _productCategoryRepository.Update(person);
            await _productCategoryRepository.UnitOfWork.CommitAsync();

            return new DomainResult<ProductCategory>(person);
        }

        public async Task<DomainResult> DeleteById(long id)
        {
            var person = await _productCategoryRepository.GetById(id);

            if (person == null) return new DomainResult().AddErrorMessage("Categoria não encontrada.");

            await _productCategoryRepository.Delete(person);
            await _productCategoryRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }
    }
}
