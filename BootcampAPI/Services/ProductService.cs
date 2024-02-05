using AutoMapper;
using BootcampAPI.DTOs;
using BootcampAPI.Entities;
using BootcampAPI.Repositories.Interfaces;
using BootcampAPI.Services.Interfaces;

namespace BootcampAPI.Services;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    public async Task<ResponseDto<Guid>> AddAsync(ProductAddDtoRequest entity)
    {
        Product? product = mapper.Map<Product>(entity);
        if (product != null)
        {
            product.Id = Guid.NewGuid();
            await unitOfWork.Products.AddAsync(product);
            await unitOfWork.SaveChangesAsync();
            return ResponseDto<Guid>.Success(product.Id);
        }
        return ResponseDto<Guid>.Fail("Empty Product!");
    }

    public async Task DeleteAsync(Guid id)
    {
        Product? product = await unitOfWork.Products.GetByIdAsync(id);
        if (product != null)
        {
            unitOfWork.Products.Delete(product);
        }
    }

    public async Task<ResponseDto<IEnumerable<ProductDto>?>> GetAllAsync()
    {
        IEnumerable<Product?> products = await unitOfWork.Products.GetAllAsync();
        if (products != null)
        {
            return ResponseDto<IEnumerable<ProductDto>?>.Success(mapper.Map<IEnumerable<ProductDto>>(products));
        }
        return ResponseDto<IEnumerable<ProductDto>?>.Fail("Empty Product!");
    }

    public async Task<ResponseDto<ProductDto?>> GetByIdAsync(Guid id)
    {
        Product? product = await unitOfWork.Products.GetByIdAsync(id);
        if (product != null)
        {
            return ResponseDto<ProductDto?>.Success(mapper.Map<ProductDto>(product));
        }
        return ResponseDto<ProductDto?>.Fail("No Record!");
    }

    public async Task UpdateAsync(ProductUpdateDtoRequest entity)
    {
        Product? product = mapper.Map<Product>(entity);
        if (product != null)
        {
            unitOfWork.Products.Update(product);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
