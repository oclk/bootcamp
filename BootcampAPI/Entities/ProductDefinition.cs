using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootcampAPI.Entities;

[Table("product_definition")]
public class ProductDefinition
{
    [Key]
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int StockCount { get; set; }
}
