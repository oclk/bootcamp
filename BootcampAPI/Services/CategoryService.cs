using AutoMapper;
using BootcampAPI.DTOs;
using BootcampAPI.Entities;
using BootcampAPI.Repositories.Interfaces;
using BootcampAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BootcampAPI.Services;

public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    public async Task<ResponseDto<Guid>> AddAsync(CategoryAddDtoRequest entity)
    {
        Category? category = mapper.Map<Category>(entity);
        if (category != null)
        {
            category.Id = Guid.NewGuid();
            await unitOfWork.Categories.AddAsync(category);
            await unitOfWork.SaveChangesAsync();
            return ResponseDto<Guid>.Success(category.Id);
        }
        return ResponseDto<Guid>.Fail("Empty Category!");
    }

    public async Task<ResponseDto<Guid>> AddWithProductsAsync(CategoryAddWithProductsDtoRequest entity)
    {
        using (IDbContextTransaction transaction = await unitOfWork.BeginTransactionAsync())
        {
            try
            {
                Category? category = mapper.Map<Category>(entity);
                if (category != null)
                {
                    category.Id = Guid.NewGuid();
                    await unitOfWork.Categories.AddAsync(category);
                    List<Product>? products = mapper.Map<List<Product>>(entity.Products);
                    if (products != null && products.Count > 0)
                    {
                        foreach (Product product in products)
                        {
                            product.CategoryId = category.Id;
                            await unitOfWork.Products.AddAsync(product);
                        }
                    }
                    await unitOfWork.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return ResponseDto<Guid>.Success(category.Id);
                }
                return ResponseDto<Guid>.Fail("Empty Category!");
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        Category? category = await unitOfWork.Categories.GetByIdAsync(id);
        if (category != null)
        {
            unitOfWork.Categories.Delete(category);
        }
    }

    public async Task<ResponseDto<IEnumerable<CategoryDto>?>> GetAllAsync()
    {
        IEnumerable<Category?> categories = await unitOfWork.Categories.GetAllAsync();
        if (categories != null)
        {
            return ResponseDto<IEnumerable<CategoryDto>?>.Success(mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
        return ResponseDto<IEnumerable<CategoryDto>?>.Fail("Empty Category!");
    }

    public async Task<ResponseDto<CategoryDto?>> GetByIdAsync(Guid id)
    {
        Category? category = await unitOfWork.Categories.GetByIdAsync(id);
        if (category != null)
        {
            return ResponseDto<CategoryDto?>.Success(mapper.Map<CategoryDto>(category));
        }
        return ResponseDto<CategoryDto?>.Fail("No Record!");
    }

    public async Task UpdateAsync(CategoryUpdateDtoRequest entity)
    {
        Category? category = mapper.Map<Category>(entity);
        if (category != null)
        {
            unitOfWork.Categories.Update(category);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
