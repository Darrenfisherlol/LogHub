using System.ComponentModel.DataAnnotations;

namespace LogHubStart.DTOs;

public class UpdateBinStorageDTO
{
    [Required(ErrorMessage = "Bin storage ID is required")]
    public int BinStorageId { get; set; }
    
    [Required(ErrorMessage = "Warehouse section ID is required")]
    public int WarehouseSectionsId { get; set; }
    
    [Required(ErrorMessage = "Row is required")]
    [StringLength(50, ErrorMessage = "Row cannot exceed 50 characters")]
    public string Row { get; set; }
}