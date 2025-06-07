
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;


public class WarehouseSection
{
    [Key]
    [Required]
    public int WarehouseSectionId { get; set; }
    
    [ForeignKey("Warehouse")]
    [Required]
    public int WarehouseId { get; set; }
    
    public Warehouse Warehouse { get; set; }
    
    [StringLength(250)]
    public string Desc { get; set; }
   
    public ICollection<StraightLine> StraightLines { get; set; }
    
    public ICollection<BinStorage> BinStorages { get; set; }
    
    public ICollection<Island> Islands { get; set; }

}