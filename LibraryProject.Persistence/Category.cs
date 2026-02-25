namespace LibraryProject.Persistence;

public sealed class Category(int Id, string CategoryName )
{
    public int Id { get; } = Id;
    public string CategoryName { get; } = CategoryName;
    
}