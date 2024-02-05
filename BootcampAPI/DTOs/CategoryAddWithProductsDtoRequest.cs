namespace BootcampAPI.DTOs;

public class CategoryAddWithProductsDtoRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<ProductAddDtoRequest>? Products { get; set; }
}
