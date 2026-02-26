using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Persistence;

public sealed class Category
{
    public int CategoryID { get; set; } 
    [StringLength(100)]
    public string CategoryName { get; set; } =string.Empty;
    
}