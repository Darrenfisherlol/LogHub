using System.ComponentModel.DataAnnotations;

namespace LogHubStart.DTOs;

public class UpdateStraightLineDTO
{
    [Required(ErrorMessage = "Straight line ID is required")]
    public int StraightLineID { get; set; }
    
    [Required(ErrorMessage = "Warehouse section ID is required")]
    public int WarehouseSectionId { get; set; }
}