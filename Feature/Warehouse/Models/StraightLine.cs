
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class StraightLine
{
    [Required]
    public int StraightLineID { get; set; }
    
    [ForeignKey("WarehouseSections")]
    [Required]
    public int WarehouseSectionId { get; set; }
    
    public WarehouseSection WarehouseSection { get; set; }
    
    public ICollection<Aisle> Aisles { get; set; }

}