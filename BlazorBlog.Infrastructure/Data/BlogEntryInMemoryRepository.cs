using BlazorBlog.Core.Entities;
using BlazorBlog.Core.Interfaces;

namespace BlazorBlog.Infrastructure.Data;

public class BlogEntryInMemoryRepository : IBlogEntryRepository
{
    private readonly InMemoryDataModel _model;

    public BlogEntryInMemoryRepository(InMemoryDataModel model)
    {
        _model = model;
    }

    public Task<BlogEntry> CreateAsync(BlogEntry entity, CancellationToken cancellationToken = default)
    {
        _model.BlogEntries.Add(entity);

        return Task.FromResult(entity);
    }

    public Task DeleteAsync(BlogEntry entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.BlogEntries.Remove(entity));
    }

    public Task<IEnumerable<BlogEntry>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.BlogEntries.AsEnumerable());
    }

    public Task<BlogEntry?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.BlogEntries.FirstOrDefault(b => b.Id == id));
    }

    public Task<IEnumerable<BlogEntry>> GetByTitle(string title, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_model.BlogEntries.Where(b => String.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<IEnumerable<BlogEntry>> Search(string searchTerm, CancellationToken cancellationToken = default)
    {
        var result = from blogEntry in _model.BlogEntries
                     where blogEntry.Title.Contains(searchTerm) || blogEntry.Author.FullName.Contains(searchTerm) || blogEntry.HtmlContent.Contains(searchTerm)
                     select blogEntry;

        return Task.FromResult(result.AsEnumerable());
    }

    public Task UpdateAsync(BlogEntry entity, CancellationToken cancellationToken = default)
    {
        var entryToEdit = _model.BlogEntries.FirstOrDefault(b => b.Id == entity.Id);

        if (entryToEdit != null)
        {
            entryToEdit.Title = entity.Title;
            entryToEdit.Author = entity.Author;
            entryToEdit.HtmlContent = entity.HtmlContent;
            entryToEdit.LastEdited = entity.LastEdited;
            entryToEdit.LastEditor = entryToEdit.LastEditor;
            return Task.CompletedTask;
        }

        return Task.FromException(new ArgumentException($"Blog entry '{entity.Title}' with id {entity.Id} not found"));
    }
}