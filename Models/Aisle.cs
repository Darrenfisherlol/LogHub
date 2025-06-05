using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LogHubStart.Models;

public class Aisle
{
    public int AisleId { get; set; }
    public int StraightLineId { get; set; }
    public string AisleName { get; set; }
}