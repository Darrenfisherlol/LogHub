
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogHubStart.Models;

public class BinStorage
{
    [Key]
    public int BinStorageId { get; set; }
    
    [ForeignKey("WarehouseSection")]
    [Required]
    public int WarehouseSectionsId { get; set; }
    
    public WarehouseSection WarehouseSection { get; set; }

    [StringLength(250)]
    public string Row { get; set; }

    public ICollection<Bin> Bins { get; set; }
}