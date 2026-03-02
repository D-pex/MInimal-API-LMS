
namespace LibraryProject.Core.Requests;

public sealed class UpdateMemberRequest
{
    public string? MemberName { get; init; }
    public string? MemberType { get; init; }
}