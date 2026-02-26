namespace LibraryProject.Core.Dtos;

public sealed class BooksDto (int ID, string BookName, string AuthorName, string Publisher, int CategoryID)
{
public int BookID { get; } = ID;
    public string BookName { get; } = BookName;
    public string AuthorName { get; } = AuthorName;
    public string PublisherName { get; } = Publisher ;
    public int CategoryID { get; } = CategoryID;
    
}