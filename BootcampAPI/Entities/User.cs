using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootcampAPI.Entities;

[Table("user")]
public class User
{
    [Key]
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string Email { get; set; } = default!;
    public List<Product>? Products { get; set; }
}
