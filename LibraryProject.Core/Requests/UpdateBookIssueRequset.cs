namespace LibraryProject.Core.Requests;

public sealed class UpdateBookIssueRequset
{
    public DateOnly ReturnDate { get; init; }
    public DateOnly RenewDate { get; init; }
}