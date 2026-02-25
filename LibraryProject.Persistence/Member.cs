namespace LibraryProject.Persistence;

public sealed class Member(int Id, string MemberName, string MemberType)
{
    public int Id { get; } = Id;
    public string MemberName { get; } = MemberName;
    public string MemberType { get; } = MemberType;
}