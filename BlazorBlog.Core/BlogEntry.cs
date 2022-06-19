namespace BlazorBlog.Core;

public class BlogEntry
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string HtmlContent { get; set; }
    public DateTimeOffset Created { get; set; }
    public Author Author { get; set; }
    public DateTimeOffset LastEdited { get; set; }
    public Author LastEditor { get; set; }

    public BlogEntry()
    {

    }
}