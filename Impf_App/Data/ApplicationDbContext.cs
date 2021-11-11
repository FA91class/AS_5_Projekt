namespace Impf_App.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
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
