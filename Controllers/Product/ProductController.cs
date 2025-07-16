using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        var product = await _context.Product.ToListAsync();
        return product;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Product.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        if (product is null)
        {
            return BadRequest();
        }

        Product addProduct = new Product
        {
            CategoryId = product.CategoryId,
            ProductCategory = product.ProductCategory,
            SKU = product.SKU,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
        };

        await _context.Product.AddAsync(addProduct);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutProduct(int id, Product updateProduct)
    {
        if (id != updateProduct.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(updateProduct).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var productExists = ProductExists(id);
        if (!productExists)
        {
            return NotFound();
        }

        var product = await _context.Product.FindAsync(id);
        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Logic
    public bool ProductExists(int id)
    {
        var doesProductExist = _context.Product.Any(e => e.ProductId == id);
        return doesProductExist;
    }
}
