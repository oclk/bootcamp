using Microsoft.EntityFrameworkCore.Storage;

namespace BootcampAPI.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    ICategoryRepository Categories { get; }
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task SaveChangesAsync();
}
