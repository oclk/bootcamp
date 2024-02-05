using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BootcampAPI.Entities;

[Table("Product")]
public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string Description { get; set; } = default!;
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; } // FK
    // Navigation Property
    public Category? Category { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public ProductFeature? ProductFeature { get; set; }
}
