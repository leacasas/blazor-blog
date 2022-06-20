using BlazorBlog.Core.Entities;
using BlazorBlog.SharedKernel.Interfaces;

namespace BlazorBlog.Core.Interfaces;

public interface IAuthorRepository : IRepository<Author>
{
    Task<IEnumerable<Author>> GetByEmail(string email, CancellationToken cancellationToken = default);
    Task<IEnumerable<Author>> Search(string searchTerm, CancellationToken cancellationToken = default);
}