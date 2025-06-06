﻿namespace LogHubStart.Models;

public class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}