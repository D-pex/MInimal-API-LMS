namespace LibraryProject.Core.Dtos;

public sealed class BooksDto (int ID, string BookName, string AuthorName, string Publisher, int CategoryID)
{
public int ID { get; } = ID;
    public string BookName { get; } = BookName;
    public string AuthorName { get; } = AuthorName;
    public string Publisher { get; } = Publisher;
    public int CategoryID { get; } = CategoryID;
    
}