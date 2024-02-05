namespace BootcampAPI.DTOs;

public class ProductUpdateDtoRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}
