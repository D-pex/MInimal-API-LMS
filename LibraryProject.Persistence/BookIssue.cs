namespace LibraryProject.Persistence;

public sealed class BookIssue
{
    public int Id { get; set; }
    public DateOnly IssueDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public DateOnly RenewDate { get; set; }
    public int BookID { get; set; }
    public int MemberID { get; set; }
}