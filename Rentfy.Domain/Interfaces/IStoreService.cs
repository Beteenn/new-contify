using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IStoreService
    {
        Task<DomainResult<Store>> Create(Store store);
        Task<DomainResult<Store>> GetById(long id);
        Task<DomainResult<Store>> Update(long id, Store storeUpdate);
        Task<DomainResult> DeleteById(long id);
    }
}
