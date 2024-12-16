using ConfigurationServices.CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationServices.CQRS.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new ConsumerSeedData());
        modelBuilder.Entity<Consumer>().Navigation(e => e.PlanType).AutoInclude();
        modelBuilder.Entity<Company>().Navigation(e => e.BusinessType).AutoInclude();
        modelBuilder.Entity<Company>().Navigation(e => e.Category).AutoInclude();
        modelBuilder.Entity<Department>().Navigation(e => e.Company).AutoInclude();
    }
    public DbSet<Consumer> Consumers { get; set; }
    public DbSet<PlanType> PlanTypes { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BusinessType> BusinessTypes { get; set; }
    public DbSet<BusinessLocation> BusinessLocations { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Designation> Designations { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationLevel> LocationLevels { get; set; }
    public DbSet<AddressDetail> AddressDetails { get; set; }
    public DbSet<OrganisationType> OrganisationTypes { get; set; }
    public DbSet<OrganisationHierarchy> OrganisationHierarchies { get; set; }
    public DbSet<LeadAgent> LeadAgents { get; set; }
    public DbSet<LeadCategory> LeadCategories { get; set; }
    public DbSet<Client> clients { get; set; }
    public DbSet<LeadStatus> LeadStatus { get; set; }
    public DbSet<LeadSource> LeadSource { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
