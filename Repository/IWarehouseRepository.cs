using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Repositories;

public interface IWarehouseRepository
{
    Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
    Task<Warehouse> GetWarehouseByIdAsync(int id);
    Task AddWarehouseAsync(Warehouse warehouse);
    Task UpdateWarehouseAsync(Warehouse warehouse);
    Task DeleteWarehouseAsync(int id);
    Task<bool> WarehouseExistsAsync(int id);
}

public class WarehouseRepository : IWarehouseRepository
{
    private readonly AppDbContext _context;

    public WarehouseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
    {
        var warehouses = await _context.Warehouses.ToListAsync();
        return warehouses;
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);
        if (warehouse is null)
            Console.WriteLine("error");
        
        return warehouse;
    }

    public async Task AddWarehouseAsync(Warehouse warehouse)
    {
        _context.Warehouses.Add(warehouse);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateWarehouseAsync(Warehouse warehouse)
    {
        _context.Entry(warehouse).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWarehouseAsync(int id)
    {
        var warehouse = await _context.Warehouses.FindAsync(id);
        if (warehouse != null)
        {
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> WarehouseExistsAsync(int id)
    {
        bool doesWarehouseExist = await _context.Warehouses
            .AnyAsync(e => e.WarehouseId == id);
        return doesWarehouseExist;
    }
}