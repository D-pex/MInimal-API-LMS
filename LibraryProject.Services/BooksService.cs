using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
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
                b.CategoryID))
            .ToList();

        return books;
    }

    public BooksDto? GetBookById(int Id)
    {
        return _DbContext.Book
            .Where(b => b.BookId == Id)
            .Select(b => new BooksDto(
                b.BookId, b.BookName, b.AuthorName, b.PublisherName, b.CategoryID))
            .FirstOrDefault();
    }

    public BooksDto? AddBooks(int CategoryID, CreateBooksRequest createBooksRequest)
    {
        var category = _DbContext.Category.FirstOrDefault(c => c.CategoryID == CategoryID);
        if (category == null) return null;

        var books = _DbContext.Book.FirstOrDefault(b =>
            b.BookName == createBooksRequest.BookName && b.AuthorName == createBooksRequest.AuthorName &&
            b.PublisherName == createBooksRequest.PublisherName
        );

        if (books is not null) return null;

        books = new Books
        {
            BookName = createBooksRequest.BookName,
            AuthorName = createBooksRequest.AuthorName,
            PublisherName = createBooksRequest.PublisherName,
            CategoryID = CategoryID
        };

        _DbContext.Add(books);
        _DbContext.SaveChanges();
        return new BooksDto(
            books.BookId,
            books.BookName,
            books.AuthorName,
            books.PublisherName,
            books.CategoryID);
    }
}