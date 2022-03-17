using System;
using System.Threading.Tasks;

namespace Contify.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
