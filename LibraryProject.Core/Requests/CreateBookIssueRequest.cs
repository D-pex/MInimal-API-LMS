namespace LibraryProject.Core.Requests;

public sealed class CreateBookIssueRequest
{
    public int MemberID { get; init; }    
    public int BookID { get; init; }

    public DateOnly IssueDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    
}