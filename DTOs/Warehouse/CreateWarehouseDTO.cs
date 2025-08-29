using System.ComponentModel.DataAnnotations;

namespace LogHubStart.DTOs;
public class CreateWarehouseDTO
{
    [Required(ErrorMessage = "Warehouse name is required")]
    [StringLength(100, ErrorMessage = "Warehouse name cannot exceed 100 characters")]
    public string WarehouseName { get; set; }

    [Required(ErrorMessage = "Address is required")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
    public string Address { get; set; }

    [StringLength(50)]
    public string State { get; set; }

    [StringLength(50)]
    public string Country { get; set; }
    
    public int ZipCode { get; set; }

    [StringLength(100)]
    public string OwnerName { get; set; } 

    [Phone(ErrorMessage = "Invalid phone number format")]
    public string Phone { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
}