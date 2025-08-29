using System.ComponentModel.DataAnnotations;

namespace LogHubStart.DTOs;

public class UpdateIslandDTO
{
    [Required(ErrorMessage = "Island ID is required")]
    public int IslandId { get; set; }
    
    [Required(ErrorMessage = "Warehouse section ID is required")]
    public int WarehouseSectionsId { get; set; }
}