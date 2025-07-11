using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;
namespace LogHubStart.Repositories;


public interface IWarehouseSectionRepository
{
    Task<IEnumerable<WarehouseSection>> GetAllWarehouseSectionsAsync();
    Task<WarehouseSection?> GetWarehouseSectionByIdAsync(int id);
    Task AddWarehouseSectionAsync(WarehouseSection warehouseSection);
    Task UpdateWarehouseSectionAsync(WarehouseSection warehouseSection);
    Task DeleteWarehouseSectionAsync(int id);
    Task<bool> WarehouseSectionExistsAsync(int id);
}

public class WarehouseSectionRepository : IWarehouseSectionRepository
{
    private readonly AppDbContext _context;

    public WarehouseSectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WarehouseSection>> GetAllWarehouseSectionsAsync(int warehouseId)
    {
        var WarehouseSections = await _context.WarehouseSection
            .Where(x => x.WarehouseId == warehouseId)
            .ToListAsync();
        return WarehouseSections;
    }

    public Task<IEnumerable<WarehouseSection>> GetAllWarehouseSectionsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<WarehouseSection?> GetWarehouseSectionByIdAsync(int id)
    {
        return await _context.WarehouseSection.FindAsync(id);
    }

    public async Task AddWarehouseSectionAsync(WarehouseSection warehouseSection)
    {
        _context.WarehouseSection.Add(warehouseSection);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWarehouseSectionAsync(WarehouseSection warehouseSection)
    {
        _context.Entry(warehouseSection).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWarehouseSectionAsync(int id)
    {
        var warehouseSection = await _context.WarehouseSection.FindAsync(id);
        if (warehouseSection != null)
        {
            _context.WarehouseSection.Remove(warehouseSection);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> WarehouseSectionExistsAsync(int id)
    {
        bool doesWarehouseSectionExist = await _context.WarehouseSection
            .AnyAsync(e => e.WarehouseSectionId == id);
        
        return doesWarehouseSectionExist;
    }
}