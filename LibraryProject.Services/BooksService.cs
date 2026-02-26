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
        
        var books = _DbContext.books
            .Include(Books => Books.Category)              
            .Select(Books => new BooksDto(
                Books.Id,
                Books.BookName,
                Books.AuthorName,
                Books.Publisher,
                Books.CategoryId,))
            .ToList();                                    
    
        return books;
    }

    public BooksDto? GetBookById(int Id)
    {
        var BookDto = _DbContext.Books
            .Where(Books  => Books.Id == Id)
            .Select(b => new BooksDto(
                Books.Id, Books.BookName, Books.AuthorName, Books.Publisher,))
            .FirstOrDefault();

        return BooksDto;

       
    }
}