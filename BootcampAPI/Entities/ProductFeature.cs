using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootcampAPI.Entities;

[Table("product_feature")]
public class ProductFeature
{
    [Key]
    public Guid Id { get; set; }
    public int Height { get; set; } = default!;
    public int Width { get; set; } = default!;
    public string Color { get; set; } = default!;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = default!;
}
