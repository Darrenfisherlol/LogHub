using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LogHubStart.Models;

public class Bin
{
    [Key]
    public int BinId { get; set; }

    [ForeignKey("BinStorage")]
    [Required]
    public int BinStorageId { get; set; }

    public BinStorage BinStorage { get; set; }

    public double BinCapacity { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
}
