using Contify.Domain.SeedWork;

namespace Contify.Domain.InterfacesRepository
{
    public interface IBaseRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
