using System.ComponentModel.DataAnnotations;

namespace LogHubStart.DTOs;

public class CreateIslandDTO
{
    [Required(ErrorMessage = "Warehouse section ID is required")]
    public int WarehouseSectionsId { get; set; }
}