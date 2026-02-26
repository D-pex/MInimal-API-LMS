namespace LibraryProject.Persistence;


public sealed class Books 
{
    public int BookId { get; set; }

    public string BookName { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string PublisherName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    
}