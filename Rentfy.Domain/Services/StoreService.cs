using Rentfy.Domain.Entities;
using Rentfy.Domain.Interfaces;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Rentfy.Domain.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task<DomainResult<Store>> GetById(long id)
        {
            var store = await _storeRepository.GetById(id);

            return new DomainResult<Store>(store);
        }

        public async Task<DomainResult<Store>> Create(Store store)
        {
            await _storeRepository.Add(store);
            await _storeRepository.UnitOfWork.CommitAsync();

            return new DomainResult<Store>(store);
        }

        public async Task<DomainResult<Store>> Update(long id, Store storeUpdate)
        {
            var store = await _storeRepository.GetById(id);

            if (store == null) return new DomainResult<Store>().AddErrorMessage("Estabelecimento não encontrado.");

            store.UpdateBasicInfo(storeUpdate);

            await _storeRepository.Update(store);
            await _storeRepository.UnitOfWork.CommitAsync();

            return new DomainResult<Store>(store);
        }

        public async Task<DomainResult> DeleteById(long id)
        {
            var store = await _storeRepository.GetById(id);

            if (store == null) return new DomainResult().AddErrorMessage("Estabelecimento não encontrado.");

            await _storeRepository.Delete(store);
            await _storeRepository.UnitOfWork.CommitAsync();

            return new DomainResult();
        }
    }
}
