using LibraryProject.Core.Dtos;
using LibraryProject.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Services;

public sealed class BookIssueService
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<BookIssueService> _logger;

    public BookIssueService(AppDbContext dbContext, ILogger<BookIssueService> logger)
    {
        _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
        _logger = logger;
        
    }

    public IEnumerable<BookIssueDto> BookIssue()
    {
        IReadOnlyList<BookIssueDto> bookIssueServices = _dbContext.BookIssues
            .Include(b => b.Book)
            .Include(m => m.Member)
            .Select(bi => new BookIssueDto(
                bi.Id,
                bi.IssueDate,
                bi.ReturnDate,
                bi.RenewDate,
                bi.BookID,
                bi.MemberID))
            .ToList();
        return bookIssueServices;
    }
    public IEnumerable<BookIssueDto> BookBySearch
}