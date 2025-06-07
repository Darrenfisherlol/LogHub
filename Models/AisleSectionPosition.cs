using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class AisleSectionPosition
{
    [Key]
    [Required]
    public int AisleSectionPositionId { get; set; }
    
    [ForeignKey("AisleSectionPosition")]
    [Required]
    public int AisleSectionId { get; set; }
    
    public AisleSection AisleSection { get; set; }
    
    [Required]
    public double PositionCapacity { get; set; }
    
    [Required]
    public double Height { get; set; }
    
    [Required]
    public double Width { get; set; }
    
    [Required]
    public double Length { get; set; }
}