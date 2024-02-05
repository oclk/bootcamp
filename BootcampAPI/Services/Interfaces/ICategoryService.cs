using BootcampAPI.DTOs;

namespace BootcampAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<ResponseDto<Guid>> AddAsync(CategoryAddDtoRequest entity);
    Task<ResponseDto<Guid>> AddWithProductsAsync(CategoryAddWithProductsDtoRequest entity);
    Task DeleteAsync(Guid id);
    Task<ResponseDto<IEnumerable<CategoryDto>?>> GetAllAsync();
    Task<ResponseDto<CategoryDto?>> GetByIdAsync(Guid id);
    Task UpdateAsync(CategoryUpdateDtoRequest entity);
}
