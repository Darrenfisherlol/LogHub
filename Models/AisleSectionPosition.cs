using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogHubStart.Models;

public class AisleSectionPosition
{
    public int AisleSectionPositionId { get; set; }
    public int AisleSectionId { get; set; }
    public double PositionCapacity { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
}