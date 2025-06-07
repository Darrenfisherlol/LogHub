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
    /// Create all entity relationships
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Warehouse>()
            .HasMany(w => w.WarehouseSections)
            .WithOne(s => s.Warehouse)
            .HasForeignKey(s => s.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Warehouse -> WarehouseSection
        modelBuilder.Entity<WarehouseSection>()
            .HasMany(w => w.Islands)
            .WithOne(i => i.WarehouseSection)
            .HasForeignKey(i => i.IslandId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // WarehouseSection -> Islands
        modelBuilder.Entity<WarehouseSection>()
            .HasMany(w => w.Islands)
            .WithOne(i => i.WarehouseSection)
            .HasForeignKey(i => i.WarehouseSectionsId)
            .OnDelete(DeleteBehavior.Cascade);

        // WarehouseSection -> Bins
        modelBuilder.Entity<WarehouseSection>()
            .HasMany(w => w.BinStorages)
            .WithOne(b => b.WarehouseSection)
            .HasForeignKey(b => b.WarehouseSectionsId)
            .OnDelete(DeleteBehavior.Cascade);

        // WarehouseSection -> StraighLine
        modelBuilder.Entity<WarehouseSection>()
            .HasMany(w => w.StraightLines)
            .WithOne(b => b.WarehouseSection)
            .HasForeignKey(b => b.WarehouseSectionId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
    
    
    /// <summary>
    /// Showcase all models we will use
    /// </summary>
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<WarehouseSection> WarehouseSections => Set<WarehouseSection>();
    public DbSet<SectionType> SectionTypes => Set<SectionType>();
    
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
    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public DbSet<InventoryMovement> InventoryMovements => Set<InventoryMovement>();
    public DbSet<ProductLocation> ProductLocations => Set<ProductLocation>();
    public DbSet<ItemStock> ItemStocks => Set<ItemStock>();

    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    
    
}



