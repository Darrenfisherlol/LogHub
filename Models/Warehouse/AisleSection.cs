using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class AisleSection
{
    [Key]
    public int AisleSectionId { get; set; }

    [ForeignKey("Aisle")]
    [Required]
    public int AisleId { get; set; }

    public Aisle Aisle { get; set; }

    [StringLength(250)]
    public string SectionName { get; set; }

    public ICollection<AisleSectionPosition> AisleSectionPositions { get; set; }
}
