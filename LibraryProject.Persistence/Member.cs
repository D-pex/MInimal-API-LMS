namespace LibraryProject.Persistence;

public sealed class Member

{
    public int Id { get; set; }
    public string MemberName { get; set; } = string.Empty;
    public string MemberType { get; set; } = string.Empty;
}