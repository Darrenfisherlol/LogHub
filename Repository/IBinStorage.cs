using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;
namespace LogHubStart.Repositories;


public interface IBinRepository
{
    Task<IEnumerable<Bin>> GetAllBinsAsync();
    Task<Bin?> GetBinByIdAsync(int id);
    Task AddBinAsync(Bin bin);
    Task UpdateBinAsync(Bin bin);
    Task DeleteBinAsync(int id);
    Task<bool> BinExistsAsync(int id);
}

public class BinRepository : IBinRepository
{
    private readonly AppDbContext _context;

    public BinRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Bin>> GetAllBinsAsync(int binId)
    {
        var Bins = await _context.Bin
            .Where(x => x.BinId == binId)
            .ToListAsync();
        return Bins;
    }

    public Task<IEnumerable<Bin>> GetAllBinsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Bin?> GetBinByIdAsync(int id)
    {
        return await _context.Bin.FindAsync(id);
    }

    public async Task AddBinAsync(Bin bin)
    {
        _context.Bin.Add(bin);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBinAsync(Bin bin)
    {
        _context.Bin.Update(bin);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBinAsync(int id)
    {
        var bin = await _context.Bin.FindAsync(id);
        if (bin != null)
        {
            _context.Bin.Remove(bin);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> BinExistsAsync(int id)
    {
        bool doesBinExist = await _context.Bin
            .AnyAsync(e => e.BinId == id);
        
        return doesBinExist;
    }
}