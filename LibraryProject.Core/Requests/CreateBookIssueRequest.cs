namespace LibraryProject.Core.Requests;

public sealed class CreateBookIssueRequest
{
    public int ID { get; }
    public DateOnly IssueDate { get; }
    public DateOnly ReturnDate { get; }
    public DateOnly RenewDate { get; }
    public int BookID { get; }
    public int MemberID { get; }
}