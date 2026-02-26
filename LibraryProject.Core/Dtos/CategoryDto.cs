namespace LibraryProject.Core.Dtos;

public sealed class CategoryDto(int ID, string CategoryName )
{
    public int ID { get; } =  ID;
    public string CategoryName { get; } = CategoryName;
    
}