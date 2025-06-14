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
        
        modelBuilder.Entity<Item>()
            .HasOne(i => i.ItemLocation)
            .WithMany(sl => sl.Items) 
            .HasForeignKey(i => i.ItemLocationId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<InventoryMovement>()
            .HasOne(m => m.ToItemLocation) 
            .WithMany() 
            .HasForeignKey(m => m.ToProductLocationId) 
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<InventoryMovement>()
            .HasOne(m => m.FromItemLocation) 
            .WithMany()
            .HasForeignKey(m => m.FromProductLocationId) 
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<InventoryMovement>()
            .HasOne(m => m.Order)
            .WithMany()
            .HasForeignKey(m => m.OrderId)
            .OnDelete(DeleteBehavior.SetNull); 

    }
    
    
    /// <summary>
    /// Showcase all models we will use
    /// </summary>
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    public DbSet<WarehouseSection> WarehouseSections => Set<WarehouseSection>();
    // public DbSet<SectionType> SectionTypes => Set<SectionType>();
    
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
    public DbSet<ItemLocation> ProductLocations => Set<ItemLocation>();
    public DbSet<Item> ItemStocks => Set<Item>();

    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
    
    
}



