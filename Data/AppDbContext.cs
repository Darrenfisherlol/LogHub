using Microsoft.EntityFrameworkCore;
using LogHubStart.Models;
using Microsoft.Extensions.Configuration;

namespace LogHubStart.Data;


public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var configSection = configBuilder.GetSection("ConnectionStrings");
        
        optionsBuilder.UseNpgsql(configSection["DefaultLocalConnection"]);

    }
    
    /// <summary>
    /// We use set bc
    ///  - DbSet<T> is not initialized, the compiler will emit warnings from them bc
    ///    the nullable reference type feature is enabled by default
    /// </summary>
    
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<WarehouseSection> WarehouseSections => Set<WarehouseSection>();
    public DbSet<Island> Islands => Set<Island>();
    public DbSet<IslandPosition> IslandPositions => Set<IslandPosition>();
    
    public DbSet<BinStorage> BinStorages => Set<BinStorage>();
    public DbSet<Bin> Bins => Set<Bin>();
    
    public DbSet<StraightLine> StraightLines => Set<StraightLine>();
    public DbSet<Aisle> Aisles => Set<Aisle>();
    public DbSet<AisleSection> AisleSections => Set<AisleSection>();
    public DbSet<AisleSectionPosition> AisleSectionPositions => Set<AisleSectionPosition>();
    
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();
    
    
    // or we can use this but a warning will show if not implemented
    // public DbSet<Warehouse> Warehouses { get; set; }


}



