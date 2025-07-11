using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;
namespace LogHubStart.Repositories;


public interface IIslandRepository
{
    Task<IEnumerable<Island>> GetAllIslandsAsync();
    Task<Island?> GetIslandByIdAsync(int id);
    Task AddIslandAsync(Island Island);
    Task UpdateIslandAsync(Island Island);
    Task DeleteIslandAsync(int id);
    Task<bool> IslandExistsAsync(int id);
}

public class IslandRepository : IIslandRepository
{
    private readonly AppDbContext _context;

    public IslandRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Island>> GetAllIslandsAsync(int islandId)
    {
        var islands = await _context.Island
            .Where(x => x.IslandId == islandId)
            .ToListAsync();
        return islands;
    }

    public Task<IEnumerable<Island>> GetAllIslandsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Island?> GetIslandByIdAsync(int id)
    {
        return await _context.Island.FindAsync(id);
    }

    public async Task AddIslandAsync(Island Island)
    {
        _context.Island.Add(Island);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIslandAsync(Island Island)
    {
        _context.Entry(Island).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteIslandAsync(int id)
    {
        var Island = await _context.Island.FindAsync(id);
        if (Island != null)
        {
            _context.Island.Remove(Island);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> IslandExistsAsync(int id)
    {
        bool doesIslandExist = await _context.Island
            .AnyAsync(e => e.IslandId == id);
        
        return doesIslandExist;
    }
}