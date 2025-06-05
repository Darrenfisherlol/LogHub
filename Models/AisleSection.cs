using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogHubStart.Models;

public class AisleSection
{
    public int AisleSectionId { get; set; }
    public int AisleId { get; set; }
    public string SectionName { get; set; }
}