namespace LibraryProject.Persistence;

public sealed class Books
{
    public int BookId { get; set; }

    public string BookName { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string PublisherName { get; set; } = string.Empty;
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } 
    public Category Category {get; set ;}
   

    public IList<BookIssue> BookIssue { get; init; } = [];
}