
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Island
{
    [Key]
    [Required]
    public int IslandId { get; set; }
    
    [ForeignKey("WarehouseSection")]
    [Required]
    public int WarehouseSectionsId { get; set; }
    public WarehouseSection WarehouseSection { get; set; }
    
    public ICollection<IslandPosition> IslandPositions { get; set; }

}