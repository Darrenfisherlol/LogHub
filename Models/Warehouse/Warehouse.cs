using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Warehouse
{
    [Required]
    public int WarehouseId { get; set; }

    [Required, StringLength(250)]
    public string WarehouseName { get; set; }

    [Required, StringLength(250)]
    public string Address { get; set; }

    [Required, StringLength(250)]
    public string State { get; set; }

    [Required, StringLength(250)]
    public string Country { get; set; }

    [Required]
    public int ZipCode { get; set; }

    [Required, StringLength(250)]
    public string OwnerName { get; set; }

    [Required, StringLength(25)]
    public int Phone { get; set; }

    [Required, StringLength(250)]
    public string Email { get; set; }

    [Required, StringLength(250)]
    public int CreatedBy { get; set; }

    [Required]
    [Column(TypeName = "DateTime")]
    public DateTime CreatedDate { get; set; }

    [Required, StringLength(250)]
    public int UpdatedBy { get; set; }

    [Required]
    [Column(TypeName = "DateTime")]
    public DateTime UpdateDate { get; set; }

    public ICollection<WarehouseSection> WarehouseSections { get; set; }
}
