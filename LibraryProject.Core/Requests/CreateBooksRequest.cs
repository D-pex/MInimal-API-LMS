namespace LibraryProject.Core.Requests;

public sealed class CreateBooksRequest( string BookName, string AuthorName, string Publisher, int CategoryID)
{
    public string BookName { get; } = BookName;
    public string AuthorName { get; } = AuthorName;
    public string PublisherName { get; } = Publisher;
    public int CategoryID { get; } = CategoryID;
} 