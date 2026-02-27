using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
using LibraryProject.Persistence;
using Microsoft.EntityFrameworkCore;
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

    public IEnumerable<MemberDto> GetMemberList()
    {
        IReadOnlyList<MemberDto> Member = _DbContext.Members
            .Include(m => m.MemberType)
            .Select(m => new MemberDto(
                m.Id,
                m.MemberName,
                m.MemberType)).ToList();

        return Member;
    }

    public MemberDto? GetMemberByID(int ID)
    {
        var Member = _DbContext.Members
            .Where(m => m.Id == ID)
            .Select(m => new MemberDto(
                m.Id,
                m.MemberName,
                m.MemberType)).FirstOrDefault();

        return Member;
    }

    public IEnumerable<MemberDto> GetMemberByType(int ID)
    {
        IReadOnlyList<MemberDto> Member = _DbContext.Members
            .Include(m => m.MemberType)
            .Where(m => m.Id == ID)
            .Select(m => new MemberDto(
                m.Id,
                m.MemberName,
                m.MemberType))
            .ToList();
        return Member;
    }
    
    public MemberDto?  AddMember( CreateMemberRequest creatememberrequest)
    {
       

        Member?  member = _DbContext.Members.FirstOrDefault(m => m.MemberName == creatememberrequest.MemberName && m.MemberType == creatememberrequest.MemberType);

        if (member is not null)
        {
            return null;
        }

        member = new Member
        {
            MemberName = creatememberrequest.MemberName,
            MemberType = creatememberrequest.MemberType,
        };
             
        _DbContext.Add(member); 
        _DbContext.SaveChanges();
        return new MemberDto(
            member.Id,
            member.MemberName,
            member.MemberType
           );
            
    }
}