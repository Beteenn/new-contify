using Contify.Data.Mapping;
using Contify.Domain.Entities;
using Contify.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contify.Data.Configuration
{
    public class ContifyContext : DbContext, IUnitOfWork
    {
        public ContifyContext(DbContextOptions<ContifyContext> options) : base(options) { }

        #region DbSets
        public DbSet<ObjetoTeste> ObjetoTestes { get; set; }


        #endregion
        public async Task<int> CommitAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ObjetoTesteMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
