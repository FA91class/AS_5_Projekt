using IdentityServer4.EntityFramework.Options;
using Impf_App.Server.Models;
using Impf_App.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Impf_App.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<VaccinationDosis> VaccinationDoses { get; set; }

        public DbSet<Vaccine> Vaccines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .Navigation(p => p.PF_Insurance).AutoInclude();

            modelBuilder.Entity<VaccinationDosis>()
                .Navigation(p => p.F_Insurance).AutoInclude();

            modelBuilder.Entity<VaccinationDosis>()
                .Navigation(p => p.F_Patient).AutoInclude();

            modelBuilder.Entity<VaccinationDosis>()
                .Navigation(p => p.F_Vaccine).AutoInclude();
        }
    }
}
