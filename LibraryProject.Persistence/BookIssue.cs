namespace LibraryProject.Persistence;

public sealed class BookIssue
{
    //[key] is the config file is not work 
    public int IssueID { get; set; }
    public DateOnly IssueDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public DateOnly? RenewDate { get; set; }
    public int BookID { get; set; }
    public int MemberID { get; set; }

    public Books Book { get; set; }
    public Member Member { get; set; }
}