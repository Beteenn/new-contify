using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Rentfy.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<DomainResult<Product>> GetById(long id)
        {
            var product = await _productRepository.GetById(id);

            return new DomainResult<Product>(product);
        }

        public async Task<DomainResult<Product>> Create(Product product)
        {
            await _productRepository.Add(product);
            await _productRepository.UnitOfWork.CommitAsync();

            return new DomainResult<Product>(product);
        }

        public async Task<DomainResult<Product>> Update(long id, Product productUpdate)
        {
            var product = await _productRepository.GetById(id);

            if (product == null) return new DomainResult<Product>().AddErrorMessage("Produto não encontrada.");

            product.UpdateBasicInfo(productUpdate);

            await _productRepository.Update(product);
            await _productRepository.UnitOfWork.CommitAsync();

            return new DomainResult<Product>(product);
        }

        public async Task<DomainResult> DeleteById(long id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null) return new DomainResult().AddErrorMessage("Produto não encontrada.");

            await _productRepository.Delete(product);
            await _productRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }
    }
}
