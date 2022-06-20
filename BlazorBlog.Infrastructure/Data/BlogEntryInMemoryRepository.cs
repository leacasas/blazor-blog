using BlazorBlog.Core.Entities;
using BlazorBlog.Core.Interfaces;

namespace BlazorBlog.Infrastructure.Data;

public class BlogEntryInMemoryRepository : IBlogEntryRepository
{
    private readonly InMemoryDataModel _model;

    public BlogEntryInMemoryRepository()
    {
        _model = new InMemoryDataModel();
    }

    public Task<BlogEntry> CreateAsync(BlogEntry entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(BlogEntry entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BlogEntry>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.BlogEntries.AsEnumerable());
    }

    public Task<BlogEntry> GetByIdAsync<Tid>(Tid id, CancellationToken cancellationToken = default) where Tid : notnull
    {
        return GetByIdAsync<int>(id, cancellationToken);
    }

    private Task<BlogEntry> GetByIdAsync<T>(object id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_model.BlogEntries.FirstOrDefault(b => b.Id == (int)id));
    }

    public Task<IEnumerable<BlogEntry>> GetByTitle(string title, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.BlogEntries.Where(b => String.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<IEnumerable<BlogEntry>> Search(string searchTerm, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(BlogEntry entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}