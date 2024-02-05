﻿namespace BootcampAPI.DTOs;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<ProductDto>? Products { get; set; }
}
