using LibraryProject.Core.Dtos;
using LibraryProject.Core.Requests;
using LibraryProject.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryProject.Web.EndPoints;

public static class MemberEndpoints
{
    public static IEndpointRouteBuilder MapMemberGroup(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGroup("member");
    }

    public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder endpoints)
    {
        ArgumentNullException.ThrowIfNull(endpoints);

        var memberGroup = endpoints.MapMemberGroup();

        memberGroup.MapGet("", Getmember);
        memberGroup.MapGet("{ID:int}", Getmember);
        memberGroup.MapGet("ByType/{ID:int}", GetMemberByType);
        memberGroup.MapPost("Add",AddMember);

        return endpoints;
    }

    private static Ok<IEnumerable<MemberDto>> Getmember(MemberServices memberServices)
    {
        var member = memberServices.GetMemberList();
        return TypedResults.Ok(member);
    }

    private static IResult GetMember(MemberServices memberServices, int ID)
    {
        var member = memberServices.GetMemberByID(ID);
        return member == null ? TypedResults.NotFound() : TypedResults.Ok(member);
    }

    private static IResult GetMemberByType(MemberServices services, int ID)
    {
        var member = services.GetMemberByType(ID);
        return TypedResults.Ok(member);
    }
    
    public static IResult AddMember(MemberServices memberServices, 
        CreateMemberRequest createMemberRequest)
    {
        MemberDto? MemberDto = memberServices.AddMember( createMemberRequest ) ;
        return MemberDto is null ? TypedResults.NotFound("Member Already Present") : TypedResults.Ok(MemberDto);

    }
    
}