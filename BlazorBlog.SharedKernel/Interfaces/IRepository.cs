namespace BlazorBlog.SharedKernel.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull;
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}