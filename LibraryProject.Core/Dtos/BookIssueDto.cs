namespace LibraryProject.Core.Dtos;

public sealed class BookIssueDto(
    int ID,
    DateOnly IssueDate,
    DateOnly ReturnDate,
    DateOnly? RenewDate,
    int BookID,
    string BookName, 
    string MemberName)
{
    public int ID { get; } = ID;
    public DateOnly IssueDate { get; } = IssueDate;
    public DateOnly ReturnDate { get; } = ReturnDate;
    public DateOnly? RenewDate { get; } = RenewDate;
    public int BookID { get; } = BookID;
    public string BookName { get; } = BookName;
    public string MemberName { get;  } = MemberName;
}