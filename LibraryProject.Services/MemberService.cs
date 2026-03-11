using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
using LibraryProject.Persistence;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Services;

public sealed class MemberServices
{
    private readonly AppDbContext _DbContext;
    private readonly ILogger<MemberServices> _logger;

    public MemberServices(AppDbContext dbContext, ILogger<MemberServices> logger)
    {
        _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger;
    }

    public IEnumerable<MemberDto> GetAllMembers()
    {
        IReadOnlyList<MemberDto> memberDtos = _DbContext.Members
            .Select(m => new MemberDto(
                m.MemberId,
                m.MemberName,
                m.MemberType)).ToList();

        return memberDtos;
    }

    public MemberDto? GetMemberById(int ID)
    {
        var memberDto = _DbContext.Members
            .Where(m => m.MemberId == ID)
            .Select(m => new MemberDto(
                m.MemberId,
                m.MemberName,
                m.MemberType)).FirstOrDefault();

        return memberDto;
    }

    public IEnumerable<MemberDto> GetMemberByType(int ID)
    {
        IReadOnlyList<MemberDto> memberDtos = _DbContext.Members
            .Where(m => m.MemberId == ID)
            .Select(m => new MemberDto(
                m.MemberId,
                m.MemberName,
                m.MemberType))
            .ToList();
        return memberDtos;
    }

    public MemberDto? AddMember(CreateMemberRequest creatememberrequest)
    {
        var member = _DbContext.Members.FirstOrDefault(m =>
            m.MemberName == creatememberrequest.MemberName && m.MemberType == creatememberrequest.MemberType);

        if (member is not null) return null;

        member = new Member
        {
            MemberName = creatememberrequest.MemberName,
            MemberType = creatememberrequest.MemberType
        };

        _DbContext.Add(member);

        _DbContext.SaveChanges();

        return new MemberDto(
            member.MemberId,
            member.MemberName,
            member.MemberType
        );
    }

    public MemberDto? UpdateMember(int id, UpdateMemberRequest updatememberrequest)
    {
        var member = _DbContext.Members.FirstOrDefault(m => m.MemberId == id);

        if (member == null)
            return null;

        member.MemberName = updatememberrequest.MemberName;
        member.MemberType = updatememberrequest.MemberType;

        _DbContext.SaveChanges();

        return new MemberDto(
            member.MemberId,
            member.MemberName,
            member.MemberType);
    }
}