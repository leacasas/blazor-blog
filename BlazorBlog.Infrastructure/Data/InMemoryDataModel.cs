using BlazorBlog.Core.Entities;

namespace BlazorBlog.Infrastructure.Data;

public class InMemoryDataModel
{
    internal IList<BlogEntry> BlogEntries { get; set; }
    internal IList<Author> Authors { get; set; }

    public InMemoryDataModel()
    {
        var testAuthor = new Author()
        {
            Id = 0,
            FullName = "Test Author",
            EmailAddress = "test.author@blog.com"
        };
        Authors = new List<Author>() { testAuthor };
        BlogEntries = new List<BlogEntry>()
        {
            new BlogEntry
            {
                Id = 0,
                Title = "Test Blog Entry",
                HtmlContent = "<h1>Test Blog Entry</h1><p>Lorem Ipson Dol Sit Amet</p>",
                Url = "test_blog_entry",
                Created = DateTime.Now,
                Author = testAuthor,
                LastEdited = DateTime.Now,
                LastEditor = testAuthor
            }
        };
    }
}
