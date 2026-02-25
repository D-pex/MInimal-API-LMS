namespace LibraryProject.Core.Requests;

public sealed class CreateBookIssueRequest
{
     public int BookId { get; init; }
     public int MemberId { get; init; }
}