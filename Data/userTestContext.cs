using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Data;

public class UserTestContext : DbContext
{
    public UserTestContext(DbContextOptions<UserTestContext> options)
        : base(options)
    {
    }

    public DbSet<UserTest> UserTests { get; set; } = null!;
}