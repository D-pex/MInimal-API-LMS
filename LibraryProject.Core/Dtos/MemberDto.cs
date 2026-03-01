namespace LibraryProject.Core.Dtos;

public sealed class MemberDto(int id, string memberName, string memberType)
{
    public int MemberId { get; } = id;
    public string MemberName { get; } = memberName;
    public string MemberType { get; } = memberType;
}