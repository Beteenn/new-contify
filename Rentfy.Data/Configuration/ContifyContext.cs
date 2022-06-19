using Rentfy.Data.Mapping;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.SeedWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentfy.Data.Configuration
{
    public class ContifyContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>,
                    UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>,
                    IdentityUserToken<long>>, IUnitOfWork
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
            #region Identity

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new UserRoleMapping());

            #endregion

            modelBuilder.ApplyConfiguration(new ObjetoTesteMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
