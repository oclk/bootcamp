using BootcampAPI.DTOs;
using BootcampAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BootcampAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpPost]
    public Task<ResponseDto<Guid>> AddAsync([FromBody] CategoryAddDtoRequest entity)
    {
        return categoryService.AddAsync(entity);
    }

    [HttpPost("AddWithProductsAsync")]
    public Task<ResponseDto<Guid>> AddWithProductsAsync([FromBody] CategoryAddWithProductsDtoRequest entity)
    {
        return categoryService.AddWithProductsAsync(entity);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await categoryService.DeleteAsync(id);
    }

    [HttpGet]
    public async Task<ResponseDto<IEnumerable<CategoryDto>>> GetAllAsync()
    {
        return await categoryService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ResponseDto<CategoryDto>> GetByIdAsync(Guid id)
    {
        return await categoryService.GetByIdAsync(id);
    }

    [HttpPut]
    public async Task UpdateAsync([FromBody] CategoryUpdateDtoRequest entity)
    {
        await categoryService.UpdateAsync(entity);
    }
}
