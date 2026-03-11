using System.Collections.ObjectModel;
using LibraryProject.Core.Dtos;
using LibraryProject.Persistence;
using Microsoft.EntityFrameworkCore;
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

    public IEnumerable<BookIssueDto> BookIssue(string? memberName = null)
    {
        IQueryable<BookIssue> query = _dbContext.BookIssue.AsQueryable();
        if(memberName != null)
        {
            query = query.Where(bi => bi.Member.MemberName.Contains(memberName));
        }
        IReadOnlyList<BookIssueDto> bookIssueServices = query
            .Include(b => b.Book)
            .Include(m => m.Member)
            .Select(bi => new BookIssueDto(
                bi.IssueID,
                bi.IssueDate,
                bi.ReturnDate,
                bi.RenewDate,
                bi.BookID,
                bi.Book.BookName,
                bi.Member.MemberName))
            .ToList();
        return bookIssueServices;
    }

    public IEnumerable<BookIssueDto> GetBookIssueBySearch(string? member = null)
    {
        IQueryable<BookIssue> query = _dbContext.BookIssue.AsQueryable();

        if (member!= null) query = query.Where(bi => bi.Member.MemberName.Contains(member));

        List<BookIssueDto> result = query
            .Include(m => m.Member)
            .Select(bi => new BookIssueDto(
                bi.IssueID,
                bi.IssueDate,
                bi.ReturnDate,
                bi.RenewDate,
                bi.BookID,
                bi.Book.BookName,
                bi.Member.MemberName
            )).ToList();

        return new ReadOnlyCollection<BookIssueDto>(result);
    } 
    
}