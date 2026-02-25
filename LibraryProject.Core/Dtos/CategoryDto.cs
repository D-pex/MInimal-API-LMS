namespace LibraryProject.Core.Dtos;

public sealed class CategoryDto(int Id, string CategoryName )
{
    public int Id { get; } = Id;
    public string CategoryName { get; } = CategoryName;
    
}