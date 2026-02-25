namespace LibraryProject.Persistence;


public sealed class Books (int Id, string BookName, string AuthorName, string Publisher, int CategoryId, string  Category)
{
    public int Id { get; } = Id;
    public string BookName { get; } = BookName;
    public string AuthorName { get; } = AuthorName;
    public string Publisher { get; } = Publisher;
    public int CategoryId { get; } = CategoryId;
    public String  Category { get; } = Category;
}