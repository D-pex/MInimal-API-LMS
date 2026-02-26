using System.Collections.ObjectModel;
using LibraryProject.Core.Dtos;
using LibraryProject.Persistence;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Services;



public sealed class CategoryServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<CategoryServices> _logger;

    public CategoryServices(AppDbContext DbContext, ILogger<CategoryServices> logger)
    {
        _DbContext = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        _logger = logger;
    }

    public IEnumerable<CategoryDto> GetCategoriesList()
    {
        IList<CategoryDto> categories = _DbContext.Categories
            .Select(c => new CategoryDto(
                c.ID,
                c.CategoryName
            ))
            .ToList();
        return new ReadOnlyCollection<CategoryDto>(categories);
    }

    public CategoryDto? GetCategoryByID(int ID)
    {
        var category = _DbContext.Categories
            .Where(c => c.ID == ID)
            .Select(c => new CategoryDto(
                c.ID,
                c.CategoryName
            ))
            .FirstOrDefault();

        if (category == null) _logger.LogWarning("Category with ID {ID} not found.", ID);

        return category;
    }
}
