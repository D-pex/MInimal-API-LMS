using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Persistence;

public sealed class BookIssue
{ 
    //[key] is the config file is not work 
    public int IssueID { get; init; }
    public DateOnly IssueDate { get; init; }
    public DateOnly ReturnDate { get; init; }
    public DateOnly? RenewDate { get; init; }
    public int BookID { get; init; }
    public int MemberID { get; init; }
    
    public Books Book { get; set; }
    public Member  Member { get; set; } 
}