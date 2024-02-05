using BootcampAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BootcampAPI.Repositories;

public class UnitOfWork(AppDbContext context, IProductRepository products, ICategoryRepository categories) : IUnitOfWork
{
    public IProductRepository Products { get; } = products;
    public ICategoryRepository Categories { get; } = categories;

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await context.Database.BeginTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
