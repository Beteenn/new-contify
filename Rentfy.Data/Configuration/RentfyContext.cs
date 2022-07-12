using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rentfy.Data.Mapping;
using Rentfy.Domain.Entities;
using Rentfy.Domain.Entities.Identity;
using Rentfy.Domain.SeedWork;
using System.Threading.Tasks;

namespace Rentfy.Data.Configuration
{
    public class RentfyContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>,
                    UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>,
                    IdentityUserToken<long>>, IUnitOfWork
    {
        public RentfyContext(DbContextOptions<RentfyContext> options) : base(options) { }

        #region DbSets
        public DbSet<ObjetoTeste> ObjetoTestes { get; set; }
        public DbSet<APerson> APeople { get; set; }
        public DbSet<PhysicalPerson> PhysicalPeople { get; set; }
        public DbSet<LegalPerson> LegalPeople { get; set; }


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

            #region Person
            modelBuilder.ApplyConfiguration(new APersonMapping());
            modelBuilder.ApplyConfiguration(new PhysicalPersonMapping());
            modelBuilder.ApplyConfiguration(new LegalPersonMapping());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
