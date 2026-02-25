namespace LibraryProject.Persistence;

public sealed class BookIssue(int Id, DateOnly IssueDate, DateOnly ReturnDate, DateOnly RenewDate , int BookID, int MemberID)
{
    public int Id { get; } = Id;
    public DateOnly IssueDate { get; } = IssueDate;
    public DateOnly ReturnDate { get; } = ReturnDate;
    public DateOnly? RenewDate { get; } = RenewDate;
    public int BookID { get; } = BookID;
    public int MemberID { get; } = MemberID;
}