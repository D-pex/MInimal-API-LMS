namespace LibraryProject.Core.Requests;

public sealed class CreateBookIssueRequest
{
     public int BookID { get; init; }
     public int MemberID { get; init; }
}