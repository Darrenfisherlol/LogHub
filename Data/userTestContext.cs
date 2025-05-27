using Microsoft.EntityFrameworkCore;

namespace UserTest.Models;

public class UserTestContext : DbContext
{
    public UserTestContext(DbContextOptions<UserTestContext> options)
        : base(options)
    {
    }

    public DbSet<UserTestContext> userTests { get; set; } = null!;
}