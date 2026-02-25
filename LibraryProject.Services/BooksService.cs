using LibraryProject.Core.Dtos;
using Microsoft.EntityFrameworkCore;
using LibraryProject.Persistence;

namespace LibraryProject.Services;

public sealed class BooksService(AppDbContext context)
{
    public IEnumerable<BooksDto> GetAll()
    {
        return context.Books
            .Include(Books => Books.Category )
            .Select(b => new BooksDto(Books.Id, Books.BookName,Books.AuthorName, Books.Publisher, Books.CategoryId))
            .ToList();
    }

    public IEnumerable<BooksDto> Search(string keyword)
    {
        keyword = keyword.ToLower();

        return context.Books
            .Include(Books => Books.Category)
            .Where( books  =>
                Books.BookName.ToLower().Contains(keyword) ||
                b.AuthorName.ToLower().Contains(keyword))
            .Select(b => new BooksDto( Books.Id, Books.BookName, Books.AuthorName, Books.Publisher, Books.BookPrice, Books.CategoryId
            ))
            .ToList();
    }
}