using Contify.Data.Configuration;
using Contify.Domain.Entities;
using Contify.Domain.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Data.Repositories
{
    public class ObjetoTesteRepository : BaseRepository<ObjetoTeste>, IObjetoTesteRepository
    {
        public ObjetoTesteRepository(ContifyContext context) : base(context) { }

        public async Task AddObject(ObjetoTeste objeto)
        {
            await _context.AddAsync(objeto);
        }

        public async Task DeleteObject(ObjetoTeste objeto)
        {
            await Task.Run(() => _context.Remove(objeto));
        }

        public async Task<ObjetoTeste> GetById(long id)
        {
            return await _context.ObjetoTestes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ObjetoTeste>> ListObjects()
        {
            return await _context.ObjetoTestes.ToListAsync();
        }

        public async Task Update(ObjetoTeste objeto)
        {
            await Task.Run(() => _context.Update(objeto));
        }
    }
}
