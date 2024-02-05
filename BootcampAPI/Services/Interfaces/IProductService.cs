using BootcampAPI.DTOs;

namespace BootcampAPI.Services.Interfaces;

public interface IProductService
{
    Task<ResponseDto<Guid>> AddAsync(ProductAddDtoRequest entity);
    Task DeleteAsync(Guid id);
    Task<ResponseDto<IEnumerable<ProductDto>?>> GetAllAsync();
    Task<ResponseDto<ProductDto?>> GetByIdAsync(Guid id);
    Task UpdateAsync(ProductUpdateDtoRequest entity);
}
