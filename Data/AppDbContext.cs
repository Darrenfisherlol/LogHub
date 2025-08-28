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
        
        
        // OrderProduct

        
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

        // InventoryMovement
        
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

        // Date stuff c# to postgres
        
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(i => i.Date)
                .HasColumnType("timestamptz");
        });
        
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(i => i.CreatedDate)
                .HasColumnType("timestamptz");
        });
        
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(i => i.CreatedDate)
                .HasColumnType("timestamptz");
        });
        
        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.Property(i => i.MovementDate)
                .HasColumnType("timestamptz");
        });
        
        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.Property(i => i.CreatedDate)
                .HasColumnType("timestamptz");
            
            entity.Property(i => i.UpdateDate)
                .HasColumnType("timestamptz");
            
        });
        
    }
    
    
    /// <summary>
    /// Showcase all models we will use
    /// </summary>
    /// 
    public DbSet<Warehouse> Warehouse => Set<Warehouse>();
    public DbSet<WarehouseSection> WarehouseSection => Set<WarehouseSection>();
    
    public DbSet<Island> Island => Set<Island>();
    public DbSet<IslandPosition> IslandPosition => Set<IslandPosition>();
    
    public DbSet<BinStorage> BinStorage => Set<BinStorage>();
    public DbSet<Bin> Bin => Set<Bin>();
    
    public DbSet<StraightLine> StraightLine => Set<StraightLine>();
    public DbSet<Aisle> Aisle => Set<Aisle>();
    public DbSet<AisleSection> AisleSection => Set<AisleSection>();
    public DbSet<AisleSectionPosition> AisleSectionPosition => Set<AisleSectionPosition>();
    
    public DbSet<Role> Role => Set<Role>();
    public DbSet<Employee> Employee => Set<Employee>();
    public DbSet<Customer> Customer => Set<Customer>();
    public DbSet<Supplier> Supplier => Set<Supplier>();

    public DbSet<InventoryMovement> InventoryMovement => Set<InventoryMovement>();
    public DbSet<ItemLocation> ItemLocation => Set<ItemLocation>();
    public DbSet<Item> Item => Set<Item>();

    public DbSet<Invoice> Invoice => Set<Invoice>();
    public DbSet<Order> Order => Set<Order>();
    public DbSet<OrderProduct> OrderProduct => Set<OrderProduct>();
    public DbSet<Product> Product => Set<Product>();
    public DbSet<ProductCategory> ProductCategory => Set<ProductCategory>();
    
    
}



