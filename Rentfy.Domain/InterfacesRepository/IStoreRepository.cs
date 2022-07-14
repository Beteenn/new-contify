using Rentfy.Domain.Entities;
using System.Threading.Tasks;

namespace Rentfy.Domain.InterfacesRepository
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        Task Add(Store store);
        Task<Store> GetById(long id);
        Task Update(Store storeUpdate);
        Task Delete(Store store);
    }
}
