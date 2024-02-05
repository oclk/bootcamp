using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootcampAPI.Entities;

[Table("category")]
public class Category
{
    [Key]
    public Guid Id { get; set; } // PK
    public string Name { get; set; } = null!;
    public List<Product>? Products { get; set; }
}
