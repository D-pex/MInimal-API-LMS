namespace LibraryProject.Core.Requests;

public sealed class CreateMemberRequest
{
    public string? MemberName { get; init; }
    public string? MemberType { get; init; }
}