
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class IslandPosition
{
    [Key]
    [Required]
    public int IslandPositionId { get; set; }
    
    [ForeignKey("Island")]
    [Required]
    public int IslandId { get; set; }
    public Island Island { get; set; }
    
    public double IslandCapacity { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }

}