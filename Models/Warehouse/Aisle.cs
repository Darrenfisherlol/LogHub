using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LogHubStart.Models;

public class Aisle
{
    [Key]
    public int AisleId { get; set; }
    
    [ForeignKey("StraightLine")]
    [Required]
    public int StraightLineId { get; set; }
    
    public StraightLine StraightLine { get; set; }
    
    [StringLength(250)]
    public string AisleName { get; set; }
    
    public ICollection<AisleSection> AisleSections { get; set; }
}