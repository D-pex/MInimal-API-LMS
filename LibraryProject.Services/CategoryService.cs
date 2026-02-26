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
        IList<CategoryDto> categories = _DbContext.Category
            .Select(c => new CategoryDto(
                c.CategoryID,
                c.CategoryName
            ))
            .ToList();
        return new ReadOnlyCollection<CategoryDto>(categories);
    }

    public CategoryDto? GetCategoryByID(int ID)
    {
        var category = _DbContext.Category
            .Where(c => c.CategoryID == ID)
            .Select(c => new CategoryDto(
                c.CategoryID,
                c.CategoryName
            ))
            .FirstOrDefault();

        if (category == null) _logger.LogWarning("Category with ID {ID} not found.", ID);

        return category;
    }
}
