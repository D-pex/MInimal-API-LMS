namespace LibraryProject.Core.Dtos;

public sealed class BooksDto (int Id, string BookName, string AuthorName, string Publisher, int CategoryId)
{
public int Id { get; } = Id;
    public string BookName { get; } = BookName;
    public string AuthorName { get; } = AuthorName;
    public string Publisher { get; } = Publisher;
    public int CategoryId { get; } = CategoryId;
    
}