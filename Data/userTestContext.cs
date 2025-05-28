using Microsoft.EntityFrameworkCore;

namespace UserTestSpace.Models;

public class UserTestContext : DbContext
{
    public UserTestContext(DbContextOptions<UserTestContext> options)
        : base(options)
    {
    }

    public DbSet<UserTest> UserTests { get; set; } = null!;
}