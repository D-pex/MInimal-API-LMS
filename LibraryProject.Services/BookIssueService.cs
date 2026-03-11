using System.Collections.ObjectModel;
using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
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
                bi.MemberID,
                bi.Member.MemberName))
            .ToList();
        return bookIssueServices;
    }

    /*public IEnumerable<BookIssueDto> GetBookIssueBySearch(string? member = null)
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
                bi.MemberID,
                bi.Member.MemberName
            )).ToList();

        return new ReadOnlyCollection<BookIssueDto>(result);
    } */
    public BookIssueDto? CreateBookIssueRequest(CreateBookIssueRequest request)
    {
        try
        {
            var book = _dbContext.Book.FirstOrDefault(b => b.BookId == request.BookID);
            var member = _dbContext.Members.FirstOrDefault(m => m.MemberId == request.MemberID);
            
            if (book == null || member == null)
                return null;
            
            var bookIssue = new BookIssue
            {
                MemberID = request.MemberID,
                BookID = request.BookID,
                IssueDate = DateOnly.FromDateTime(DateTime.Today),
                ReturnDate = DateOnly.FromDateTime(DateTime.Today).AddDays(15)
            };
            _dbContext.Add(bookIssue);
            _dbContext.SaveChanges();
            
            return new BookIssueDto(
                bookIssue.IssueID,
                bookIssue.IssueDate,
                bookIssue.ReturnDate,
                bookIssue.RenewDate,
                bookIssue.BookID,
                book.BookName,
                bookIssue.MemberID,
                member.MemberName
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Unexpected error while creating Books Issue for Member Id {MemberID} ",
                request.MemberID);
        }
        return null;
    }
}