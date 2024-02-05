using BootcampAPI.Entities;
using BootcampAPI.Repositories.Interfaces;

namespace BootcampAPI.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
}
