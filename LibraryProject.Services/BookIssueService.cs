using LibraryProject.Core.Dtos;
using LibraryProject.Core;
using LibraryProject.Persistence;
using Microsoft.EntityFrameworkCore;



namespace LibraryProject.Services;



public sealed class BookIssueService(AppDbContext context)
{
    public void BookIssue(BookIssueRequest request)
    {
        var member = context.Members.Find(request.MemberId)
                     ?? throw new Exception("Member not found");

        var activeCount = context.BookIssues
            .Count(BookIssue => .MemberId == request.MemberId && x.ReturnDate == null);

        if (member.MemberType == "Premium" && activeCount >= 4)
            throw new ConflictException("Premium member max 4 books");

        if (member.MemberType == "Standard" && activeCount >= 2)
            throw new ConflictException("Standard member max 2 books");

        var alreadyIssued = context.BookIssued
            .Any(x => x.BookId == request.BookId && x.ReturnDate == null);

        if (alreadyIssued)
            throw new ConflictException("Book already issued");

        context.BookIssued.Add(new BookIssued
        {
            BookId = request.BookId,
            MemberId = request.MemberId,
            IssueDate = DateTime.Now
        });

        context.SaveChanges();
    }

    public void Renew(RenewRequest request)
    {
        var issue = context.BookIssued.Find(request.IssueId)
                    ?? throw new Exception("Issue not found");

        if (issue.RenewDate != null)
            throw new ConflictException("Book can renew only once");

        issue.RenewDate = DateTime.Now;
        issue.RenewReturnDate = DateTime.Now.AddDays(7);

        context.SaveChanges();
    }

    public IEnumerable<IssueDto> GetAll()
    {
        return context.BookIssued
            .Include(x => x.Book)
            .Include(x => x.Member)
            .Select(x => new IssueDto(
                x.Id,
                x.Book!.Name,
                x.Member!.MemberName,
                x.IssueDate,
                x.ReturnDate,
                x.RenewDate,
                x.RenewReturnDate
            ))
            .ToList();
    }
}