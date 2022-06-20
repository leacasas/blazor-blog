using BlazorBlog.Core.Entities;
using BlazorBlog.SharedKernel.Interfaces;

namespace BlazorBlog.Core.Interfaces;

public interface IBlogEntryRepository : IRepository<BlogEntry>
{
    Task<IEnumerable<BlogEntry>> GetByTitle(string title, CancellationToken cancellationToken = default);
    Task<IEnumerable<BlogEntry>> Search(string searchTerm, CancellationToken cancellationToken = default);
}