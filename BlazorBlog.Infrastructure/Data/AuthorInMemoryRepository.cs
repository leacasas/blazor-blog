using BlazorBlog.Core.Entities;
using BlazorBlog.Core.Interfaces;

namespace BlazorBlog.Infrastructure.Data;
public class AuthorInMemoryRepository : IAuthorRepository
{
    private readonly InMemoryDataModel _model;

    public AuthorInMemoryRepository(InMemoryDataModel model)
    {
        _model = model;
    }

    public Task<Author> CreateAsync(Author entity, CancellationToken cancellationToken = default)
    {
        _model.Authors.Add(entity);

        return Task.FromResult(entity);
    }

    public Task DeleteAsync(Author entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.Authors.Remove(entity));
    }

    public Task<IEnumerable<Author>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.Authors.AsEnumerable());
    }

    public Task<IEnumerable<Author>> GetByEmail(string email, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.Authors.Where(a => String.Equals(a.EmailAddress, email, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.Authors.FirstOrDefault(a => a.Id == id));
    }

    public Task<IEnumerable<Author>> Search(string searchTerm, CancellationToken cancellationToken = default)
    {
        var result = from author in _model.Authors
                     where author.FullName.Contains(searchTerm) || author.EmailAddress.Contains(searchTerm)
                     select author;

        return Task.FromResult(result.AsEnumerable());
    }

    public Task UpdateAsync(Author entity, CancellationToken cancellationToken = default)
    {
        var authorToEdit = _model.Authors.FirstOrDefault(a => a.Id == entity.Id);

        if (authorToEdit != null)
        {
            authorToEdit.FullName = entity.FullName;
            authorToEdit.EmailAddress = entity.EmailAddress;
        }

        return Task.FromException(new ArgumentException($"Author '{entity.FullName}'({entity.EmailAddress}) with id {entity.Id} not found"));
    }
}