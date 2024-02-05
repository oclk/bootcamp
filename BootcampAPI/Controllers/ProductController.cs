using BootcampAPI.DTOs;
using BootcampAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BootcampAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public Task<ResponseDto<Guid>> AddAsync([FromBody] ProductAddDtoRequest entity)
    {
        return productService.AddAsync(entity);
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await productService.DeleteAsync(id);
    }

    [HttpGet]
    public async Task<ResponseDto<IEnumerable<ProductDto>>> GetAllAsync()
    {
        return await productService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ResponseDto<ProductDto>> GetByIdAsync(Guid id)
    {
        return await productService.GetByIdAsync(id);
    }

    [HttpPut]
    public async Task UpdateAsync([FromBody] ProductUpdateDtoRequest entity)
    {
        await productService.UpdateAsync(entity);
    }
}
