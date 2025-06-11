using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class ItemLocation
{
    [Key]
    public int itemLocationId { get; set; }
    
    [ForeignKey("IslandPosition")]
    public int IslandPositionId { get; set; }
    public IslandPosition IslandPosition { get; set; }
    
    [ForeignKey("Bin")]
    public int BinId { get; set; }
    public Bin Bin { get; set; }
    
    [ForeignKey("AisleSectionPosition")]
    public int PositionId { get; set; }
    public AisleSectionPosition AisleSectionPosition { get; set; }
    
    public ICollection<Item> Items { get; set; } = new List<Item>();

}