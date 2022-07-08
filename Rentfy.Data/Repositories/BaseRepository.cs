using Rentfy.Data.Configuration;
using Rentfy.Domain.InterfacesRepository;
using Rentfy.Domain.SeedWork;
using System;

namespace Rentfy.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RentfyContext _context;
        
        public BaseRepository(RentfyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;
    }
}
