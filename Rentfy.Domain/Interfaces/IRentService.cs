using Rentfy.Domain.Entities;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Domain.Interfaces
{
    public interface IRentService
    {
        Task<DomainResult<Rent>> GetById(long id);
        Task<DomainResult<Rent>> Create(Rent rent);
        Task<DomainResult> CancelRent(long rentId);
    }
}
