using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductCategoryController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<ProductCategory>> GetProductCategorys()
    {
        var productCategory = await _context.ProductCategory.ToListAsync();
        return productCategory;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
    {
        var productCategory = await _context.ProductCategory.FindAsync(id);

        if (productCategory == null)
        {
            return NotFound();
        }

        return productCategory;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
    {
        if (productCategory is null)
        {
            return BadRequest();
        }
        
        ProductCategory addProductCategory = new ProductCategory
        {
            CategoryName = productCategory.CategoryName,
            CategoryDescription = productCategory.CategoryDescription
        };

        await _context.ProductCategory.AddAsync(addProductCategory);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetProductCategory), new { id = ProductCategory.ProductCategoryId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutProductCategory(int id, ProductCategory updateProductCategory)
    {
        if (id != updateProductCategory.ProductCategoryId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateProductCategory).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductCategoryExists(id))
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
    public async Task<IActionResult> DeleteProductCategory(int id)
    {
        var productCategoryExists = ProductCategoryExists(id);
        if (!productCategoryExists)
        {
            return NotFound();
        }
        
        var productCategory = await _context.ProductCategory.FindAsync(id);
        _context.ProductCategory.Remove(productCategory);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool ProductCategoryExists(int id)
    {
        var doesProductCategoryExist = _context.ProductCategory
            .Any(e => e.ProductCategoryId == id);
        return doesProductCategoryExist;
    }
}
