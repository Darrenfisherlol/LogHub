using System.ComponentModel.DataAnnotations;

namespace LogHubStart.DTOs;

public class CreateStraightLineDTO
{
    [Required(ErrorMessage = "Warehouse section ID is required")]
    public int WarehouseSectionId { get; set; }
}