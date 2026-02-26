using LibraryProject.Core.Dtos;
using LibraryProject.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
        var books = _DbContext.Book
            .Include(b => b.Category)
            .Select(b => new BooksDto(
                b.BookId,
                b.BookName,
                b.AuthorName,
                b.PublisherName,
                b.CategoryId))
            .ToList();

        return books;
    }

    public BooksDto? GetBookById(int Id)
    {
        return _DbContext.Book
            .Where(b => b.BookId == Id)
            .Select(b => new BooksDto(
                b.BookId, b.BookName, b.AuthorName, b.PublisherName, b.CategoryId))
            .FirstOrDefault();
    }
}