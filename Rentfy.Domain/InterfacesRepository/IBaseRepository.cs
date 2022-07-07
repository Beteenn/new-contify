using Rentfy.Domain.SeedWork;

namespace Rentfy.Domain.InterfacesRepository
{
    public interface IBaseRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
