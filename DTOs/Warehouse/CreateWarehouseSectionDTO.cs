using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.DTOs;

public class CreateWarehouseSectionDTO
{
  
    [ForeignKey("Warehouse")]
    [Required]
    public int WarehouseId { get; set; }
    
    [StringLength(250)]
    public string Desc { get; set; }
}