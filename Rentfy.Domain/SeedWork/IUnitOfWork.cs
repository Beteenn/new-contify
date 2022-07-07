using System;
using System.Threading.Tasks;

namespace Rentfy.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
