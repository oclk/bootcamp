using BootcampAPI.Entities;
using BootcampAPI.Repositories.Interfaces;
namespace BootcampAPI.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
}
