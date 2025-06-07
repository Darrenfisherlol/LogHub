
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Warehouse
{
    [Key]
    [Required]
    public int WarehouseId { get; set; }
    
    [Required, StringLength(250)]
    public string WarehouseName { get; set; }
    
    [Required, StringLength(250)]
    public string Address { get; set; }
    
    [Required, StringLength(250)]
    public string State { get; set; }
    
    [Required, StringLength(250)]
    public string Country { get; set; }
    
    [Required]
    public int ZipCode { get; set; }
    
    [Required, StringLength(250)]
    public string OwnerName { get; set; }
    
    [Required, StringLength(25)]
    public string Phone { get; set; }
    
    [Required, StringLength(250)]
    public string Email { get; set; }
    
    [Required, StringLength(250)]
    public string CreatedBy { get; set; }
    
    [Required]
    [Column(TypeName = "datetimeoffset")]
    public DateTimeOffset CreatedDate { get; set; }
    
    [Required, StringLength(250)]
    public string UpdatedBy { get; set; }
    
    [Required]
    [Column(TypeName = "datetimeoffset")]
    public DateTimeOffset UpdateDate { get; set; }
    
    public ICollection<WarehouseSection> WarehouseSections { get; set; }

}