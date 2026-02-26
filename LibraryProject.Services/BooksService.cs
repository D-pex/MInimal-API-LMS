using LibraryProject.Core.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LibraryProject.Persistence;

namespace LibraryProject.Services;

public sealed class BooksService
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<BooksService> _logger;

    public BooksService(AppDbContext dbContext, ILogger<BooksService> logger)
    {
        _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger;
    }

    public IEnumerable<BooksDto> GetBooksList()
    {
        
        var books = _DbContext.Books
            .Include(b => b.Category)              
            .Select(b => new BooksDto(
                b.Id,
                b.BookName,
                b.AuthorName,
                b.Publisher,
                b.CategoryId))
            .ToList();                                    
    
        return books;
    }

    public BooksDto? GetBookById(int Id)
    {
        return _DbContext.Books
            .Where(b  => b.Id == Id)
            .Select(b => new BooksDto(
                b.Id, b.BookName, b.AuthorName, b.Publisher,b.CategoryId))
            .FirstOrDefault();
        
    }
}