using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly AppDbContext _context;

    public InvoiceController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Invoice>> GetInvoices()
    {
        var Invoice = await _context.Invoice.ToListAsync();
        return Invoice;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Invoice>> GetInvoice(int id)
    {
        var invoice = await _context.Invoice.FindAsync(id);

        if (invoice == null)
        {
            return NotFound();
        }

        return invoice;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
    {
        if (invoice is null)
        {
            return BadRequest();
        }
        
        Invoice addInvoice = new Invoice
        {
            CustomerId = invoice.CustomerId,
            Customer = invoice.Customer,
            SupplierId = invoice.SupplierId,
            Supplier = invoice.Supplier,
            Date = invoice.Date,
            Amount = invoice.Amount,
            Tax = invoice.Tax
        };

        await _context.Invoice.AddAsync(addInvoice);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetInvoice), new { id = Invoice.InvoiceId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutInvoice(int id, Invoice updateInvoice)
    {
        if (id != updateInvoice.InvoiceId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateInvoice).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InvoiceExists(id))
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
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var invoiceExists = InvoiceExists(id);
        if (!invoiceExists)
        {
            return NotFound();
        }
        
        var invoice = await _context.Invoice.FindAsync(id);
        _context.Invoice.Remove(invoice);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool InvoiceExists(int id)
    {
        var doesInvoiceExist = _context.Invoice
            .Any(e => e.InvoiceId == id);
        return doesInvoiceExist;
    }
}
