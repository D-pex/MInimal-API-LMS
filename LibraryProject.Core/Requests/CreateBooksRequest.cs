namespace LibraryProject.Core.Requests;

public sealed class CreateBooksRequest
{
    public string BookName { get; init; }
    public string AuthorName { get; init; }
    public string PublisherName { get; init; }

    public int CategoryID { get; init; }
}