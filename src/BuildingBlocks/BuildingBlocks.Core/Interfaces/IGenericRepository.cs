namespace BuildingBlocks.Core.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task AddModelAsync(T model, CancellationToken cancellationToken);
    Task UpdateModelAsync(T model, CancellationToken cancellationToken);
    Task DeleteModelAsync(Guid id, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<bool> EntityExistsAsync(Guid id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
